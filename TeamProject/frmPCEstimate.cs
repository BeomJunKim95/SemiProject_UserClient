using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamProjectVO;
using TeamProject.UserControls;
using TeamProjectDAC;
using System.Globalization;

namespace TeamProject
{
    public partial class frmPCEstimate : Form
    {
        List<(string Feature_Name, string Valuse)> SelectComboxValuse;
        List<ProductListVO> ProductLists;

        public frmPCEstimate()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            txt_maxPrice.KeyPress += UtilEvent.TextBoxIsDigit;
            btnMyInfo.Visible = btnLogout.Visible = false;
            btnLogin.Visible = true;
            SetComboxValuse();
            ProductFeature.ChangedCombox += (sd, Event) => { SetComboxValuse(); };

            Categories_Service service = new Categories_Service();
            int i = 0;
            service.SelectCategoriesFromDivisionID(2).ForEach((VO) =>    //DivitionID 2인 값은 부품
            {
                pnl_Categories.Controls.Add(new CategoriesList(VO)
                { Location = new Point(0, i++ * 26), Size = new Size(332, 27), Name = VO.Category_Name });
            });

            SetAllCategorieComboEvent();

        }

        #region 카테고리 유저 컨트롤러 이벤트 상속
        /// <summary>
        /// 카테고리 이벤트를 등록하는 메서드 무엇이 선택됬는가를 보고 이를 확인
        /// </summary>
        private void SetAllCategorieComboEvent()
        {
            CommonUtil.ControlAction<Panel, CategoriesList>(pnl_Categories, (control) => //카테고리 페널에서 모든 카테고리 컨트롤러 를 찾음
            {
                control.ThisClick += (User, Event) =>   //모든 컨트롤러의 이벤트 할당(해당 이벤트는 컨트롤러 클릭의 이벤트 : 유저이벤트 )
                {
                    lbl_Categorie_Name.Text = control.Vo.Category_Name; //카테고리 이름을 콤보박스 페널에 알려줌
                    CommonUtil.ControlAction<Panel, CategoriesList>(pnl_Categories, (Uscontrol) => //카테고리 페널에서 모든 카테고리 컨트롤러를 찾음 
                    {
                        CategoriesList temp = (CategoriesList)Uscontrol;
                        if (temp == control)    //해당 카테고리 컨트롤러를 선택
                        {
                            temp.BackColor = Color.Aquamarine;
                            temp.Selected = true;
                            ProductFeature.BaindingCombox(temp.Vo.Category_ID);  //해당 카테고리의 속성에 따라 바인딩
                            SetProdects(temp.Vo.Category_ID);
                        }
                        else        //선택되지 못한 다른 컨트롤러들
                        {
                            temp.BackColor = SystemColors.Control;
                            temp.Selected = false;
                        }
                    });
                };
            });
        }
        #endregion

        #region  카테고리 All Product 리스트를 Set
        /// <summary>
        ///  스토어드 프로시저를 실행하여 카테고리별 모든 Product 리스트를 가져옴
        /// </summary>
        /// <param name="Category_ID"></param>
        private void SetProdects(int Category_ID)    //스토어드 프로시저 사용 내일 할일
        {
            Product_Service service = new Product_Service();
            ProductLists = service.ProductJoinProp(Category_ID);
            SetProductItem(ProductLists);
        }
        #endregion

        #region  해당 List에따라 아이템 세팅
        /// <summary>
        ///  Product 리스트를 확인하고 이에 따라 세팅
        /// </summary>
        /// <param name="ProductLists">세팅할 Product 리스트</param>
        private void SetProductItem(List<ProductListVO> ProductLists)
        {
            int i = 0;
            Pnl_prol.Controls.Clear();
            ProductLists.ForEach((temp) =>
            {
                ProductInfo info = new ProductInfo(temp)
                {
                    Size = new Size(588, 90),
                    Location = new Point(0, 90 * i++)
                };
                Pnl_prol.Controls.Add(info);
                info.btnClick += FrmPCEstimate_btnClick;
            });
        }
        #endregion

        #region 콤보박스선택에 따른 물건선택
        /// <summary>
        /// 콤보박스 선택에 따라 물건을 확인
        /// </summary>
        private void SetComboxValuse()
        {
            SelectComboxValuse = CommonUtil.ControlFunc<Panel, (string Feature_Name, string Valuse), ComboBox>(ProductFeature.PnlFeatures, (Control) =>
            {
                return (Control.Name, Control.SelectedValue.ToString());
            });

            if (ProductLists == null)
                return;
            var SelectProducts = (from pa in ProductLists select pa).ToList();   //모든 All 리스트 복사 링큐  딥복사 참복사x
            List<ProductListVO> ProductsBuff = new List<ProductListVO>();   //일종의 버퍼로 사용
            SelectComboxValuse.ForEach((Itemp) =>
            {
                if (Itemp.Valuse != "0")
                {              // 콤보박스가 선택되면 0이아닌값 예) 0=> 제조사 , 1 =>인텔 ,2 => AMD
                    SelectProducts.ForEach((ProductItemp) => {   //현재 리스트 를 반복
                        ProductItemp.Product_Info_ID.Split('/').ToList().ForEach((ID) =>
                        {
                            if (ID == Itemp.Valuse) ProductsBuff.Add(ProductItemp);
                        });

                    });
                    SelectProducts = (from pa in ProductsBuff select pa).ToList();  //일단 선택된 리스트들을 다시 복사
                    ProductsBuff = new List<ProductListVO>();               //버퍼를 비움
                }
            });
            SetProductItem(SelectProducts);     //선택된 값에 따라 리스트 확인
        }
        #endregion

        #region 카테고리 로케이션 다시 잡음
        private void SetCatagorisLocation() //모든 카테고리 로케이션 잡기
        {
            CategoriesList temp = null;     //일종의 버퍼로 활용
            CommonUtil.ControlAction<Panel, CategoriesList>(pnl_Categories, (control) => //카테고리 페널에서 모든 카테고리 컨트롤러 를 찾음
            {
                if (temp != null)   //첫번째가 아니라면
                {
                    //temp는 Controls의 전 컨트롤러'
                    //temp의 높이와 로케이션을 가져와 그 값으로 사용
                    control.Location = new Point(control.Location.X, temp.Location.Y + temp.Height);
                }
                temp = control; //첫번째라면 
            });
        }
        #endregion

        #region 이벤트

        #region 상품 담기 버튼
        /// <summary>
        /// 상품의 담기 버튼 이벤트 해당 내용
        /// </summary>
        /// <param name="sender">선택한ProductInfo</param>
        /// <param name="e">EventArgs</param>
        public void FrmPCEstimate_btnClick(object sender, EventArgs e)
        {
            ProductInfo Info = (ProductInfo)sender;
            CategoriesList Selected = null;
            CommonUtil.ControlAction<Panel, CategoriesList>(pnl_Categories, (control) => //카테고리 페널에서 모든 카테고리 컨트롤러 를 찾음
            {
                if (control.Selected)   //지금 선택된 CategoriesList 를찾음
                {
                    Selected = control;
                }
            });
            if (Selected == null)   //선택한 카테고리가 없으면
                return;

            if (Selected.ProductInfoID.Contains(Info.VO.Product_ID))    //이미 아이템이 추가되있으면
            {
                CommonUtil.ControlAction<CategoriesList, AddProduct_Control>(Selected, (AddControl) =>
                {
                    if(Info.VO.Product_ID == AddControl.ProdID)
                    {
                        AddControl.ProdCount += 1;
                        return;
                    }
                });
                return;
            }
            Selected.ProductInfoID.Add(Info.VO.Product_ID);
            AddProduct_Control addProduct = new AddProduct_Control(Info.VO)
            {
                Name = Convert.ToString(Info.VO.Product_ID),
                Location = new Point(3, Selected.Height - 3),
                Size = new Size(325, 30)
            };
            Selected.Controls.Add(addProduct);
            Selected.Height += 30;
            SetCatagorisLocation();

            lbl_Price.Text = CommonUtil.ConvertToIntFromPrice(SetProuctsPrice());



            addProduct.CountChangedEvent += (control, even) =>      //컨트롤러 콤보박스 체인지 이벤트 상속
            {
                lbl_Price.Text = CommonUtil.ConvertToIntFromPrice(SetProuctsPrice());
            };
            addProduct.DelClickEvent += (control, even) =>
            {
                Selected.Controls.Remove(addProduct);                           //선택한 컨트롤에서 해당 부품 삭제
                Selected.ProductInfoID.Remove(Convert.ToInt32(addProduct.Name));//선택한 컨트롤에서 해당 부품리스트에서 삭제
                Selected.Size = new Size(332, 27);
                CommonUtil.ControlAction<CategoriesList, AddProduct_Control>(Selected, (Addcontrol) => //카테고리 페널에서 모든 카테고리 컨트롤러 를 찾음
                {
                    Addcontrol.Location = new Point(3, Selected.Height - 3);
                    Selected.Height += 30;
                });
                SetCatagorisLocation();
                lbl_Price.Text = CommonUtil.ConvertToIntFromPrice(SetProuctsPrice());
            };

        }

        #endregion


        #region 상품들의 가격 확인
        public int SetProuctsPrice()
        {
            int price = 0;
            CommonUtil.ControlAction<Panel, CategoriesList>(pnl_Categories, (control) => //카테고리 페널에서 모든 카테고리 컨트롤러 를 찾음
            {
                CommonUtil.ControlFunc<CategoriesList, int, AddProduct_Control>(control, (AddControl) => {
                    return AddControl.ProdPrice;
                }).ForEach((returnprice) => { price += returnprice; });

            });
            return price;
        }
        #endregion

        #region 가격 라벨 위치 고정
        private void lbl_Price_SizeChanged(object sender, EventArgs e)
        {
            lbl_Price.Location = new Point(350 - lbl_Price.Size.Width, lbl_Price.Location.Y);
        }
        #endregion

        #region 모든 상품 삭제
        private void btn_AlladdProductDelete_Click(object sender, EventArgs e)
        {
            List<AddProduct_Control> temp = new List<AddProduct_Control>();
            CommonUtil.ControlAction<Panel, CategoriesList>(pnl_Categories, (categoriesControl) =>
            {
                CommonUtil.ControlAction<CategoriesList, AddProduct_Control>(categoriesControl, (AddProductcontrol) =>
                {
                    temp.Add(AddProductcontrol);
                });
            });
            temp.ForEach((control) =>
            {
                control.DeleteProductClick();   //삭제 이벤트 실행
            });
        }
        #endregion

        #region 호환성체크
        private void btn_compatibility_Click(object sender, EventArgs e)
        {
            Dictionary<string, List<ProductListVO>> valuePairs = new Dictionary<string, List<ProductListVO>>();
            CommonUtil.ControlAction<Panel, CategoriesList>(pnl_Categories, (Catagris) =>
            {

                var add = CommonUtil.ControlFunc<CategoriesList, ProductListVO, AddProduct_Control>(Catagris, (addProduct) =>
                {
                    return addProduct.Vo;
                });
                if (add.Count > 0)
                    valuePairs.Add(Catagris.Name, add);
            });
            CommonUtil.OpenCreateForm<frmCompatibilityCheck>(() => new frmCompatibilityCheck(valuePairs));
        }
        #endregion

        #endregion

        private void btn_AddWishList_Click(object sender, EventArgs e)
        {
            // 로그인 확인
            if (GlobalUser.LoginUserInfo == null)
            {
                MessageBox.Show("로그인을 하십시오.");
                return;
            }
            if (GlobalUser.LoginUserInfo.user_Deleted == "Y")
            {
                MessageBox.Show("탈퇴된 회원입니다.");
                return;
            }
            Dictionary<int, int> list = new Dictionary<int, int>();

            CommonUtil.ControlAction<Panel, CategoriesList>(pnl_Categories, (ctrl) =>
            {
                CommonUtil.ControlAction<CategoriesList, AddProduct_Control>(ctrl, (add) => 
                {
                    list.Add(add.ProdID, add.ProdCount);
                });
            });

            if(list.Count < 1)
            {
                MessageBox.Show("제품을 1개 이상 등록해주세요");
                return;
            }

            if(cbx_maxPrice.Checked)
            {
                string tot = lbl_Price.Text.Replace(",", "").Substring(1);
                if (int.Parse(txt_maxPrice.Text) < int.Parse(tot))
                {
                    if (MessageBox.Show("구매 예산을 넘어갑니다. 찜목록에 등록하시겠습니까?", "예산초과", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                }
            }

            User_Service service = new User_Service();
            if(service.AddWishList(new WishListVO { ItemList = list, User_ID = lbl_id.Text, NickName = txt_WishName.Text}))
            {
                MessageBox.Show("추가에 성공했습니다.");
                txt_WishName.Text = "";
                btn_AlladdProductDelete.PerformClick();
            }
            else
                MessageBox.Show("추가중 오류가 발생했습니다.");
        }


        #region 이승원

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();

            if (login.ShowDialog(this) == DialogResult.OK)
            {
                lblUserName.Text = GlobalUser.LoginUserInfo.user_Name;
                lbl_id.Text = GlobalUser.LoginUserInfo.user_ID;
                btnMyInfo.Visible = btnLogout.Visible = true;
                btnLogin.Visible = false;
            }
            
        }

        private void btnMyInfo_Click(object sender, EventArgs e)
        {
            frm_User_Menu frm = new frm_User_Menu();
            if (frm.ShowDialog() == DialogResult.No)
            {
                lblUserName.Text = "";
                lbl_id.Text = "";
                btnMyInfo.Visible = btnLogout.Visible = false;
                btnLogin.Visible = true;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            lblUserName.Text = "";
            lbl_id.Text = "";
            GlobalUser.LoginUserInfo = null;
            btnMyInfo.Visible = btnLogout.Visible = false;
            btnLogin.Visible = true;
        }

        #endregion

        private void txt_WishName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '_')
            {
                e.Handled = true;
            }
        }

        private void cbx_maxPrice_CheckedChanged(object sender, EventArgs e)
        {
            txt_maxPrice.Enabled = cbx_maxPrice.Checked;
        }
    }
}
