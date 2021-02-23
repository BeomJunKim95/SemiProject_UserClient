using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamProjectVO;

namespace TeamProject
{
    public partial class frm_User_Menu : Form
    {
        List<MyWishInfoVO> allList;
        public frm_User_Menu()
        {
            InitializeComponent();
        }

        private void frm_User_Menu_Load(object sender, EventArgs e)
        {
            ShowMyInfo(); // 내정보
            ShowWishList();
            ShowCartList();
            ShowPurchaseList();
        }

        #region 내정보
        private void ShowMyInfo()
        {
            #region 로그인정보를 내정보의 텍스트에 뿌려줌
            string[] userMail = GlobalUser.LoginUserInfo.user_Email.Split('@');

            txtUserID.Text = GlobalUser.LoginUserInfo.user_ID;
            txtUserName.Text = GlobalUser.LoginUserInfo.user_Name;
            txtUserPhone1.Text = GlobalUser.LoginUserInfo.user_Phone.Substring(0, 3);
            txtUserPhone2.Text = GlobalUser.LoginUserInfo.user_Phone.Substring(3, 4);
            txtUserPhone3.Text = GlobalUser.LoginUserInfo.user_Phone.Substring(7, 4);
            txtUserEmail1.Text = userMail[0];
            txtUserEmail2.Text = userMail[1];

            SetEvent(); // 설정한 이벤트 호출

            #endregion
        }

        #region 버튼 클릭

        #region 회원탈퇴 버튼
        /// <summary>
        /// 회원탈퇴 버튼을 누르면 확인받고 Yes를 누르면 DB에 Deleted를 Y로 바꿔줌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWithdrawal_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("회원탈퇴를 하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                UserInfoVO vo = new UserInfoVO { user_ID = GlobalUser.LoginUserInfo.user_ID, user_Deleted = GlobalUser.LoginUserInfo.user_Deleted };
                User_Service service = new User_Service();
                bool UserID = service.UserWithdrawal(vo.user_ID, vo.user_Deleted);

                if (UserID)
                {
                    MessageBox.Show("회원이 탈퇴되었습니다.");
                    this.DialogResult = DialogResult.No;
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("회원탈퇴를 실패하셨습니다.");
                    this.Close();
                }

            }
            else
            {
                return;
            }
        }
        #endregion

        #region 비밀번호 수정하기버튼
        /// <summary>
        /// 입력받은 비밀번호를 DB에 연결해서 Update 해줌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUserInfoUpdate_Click(object sender, EventArgs e)
        {
            if ((lblPwdfail1.Visible || lblPwdfail2.Visible))
            {
                MessageBox.Show("비밀번호 확인을 실패하였습니다.");
                return;
            }

            UserInfoVO vo = new UserInfoVO { user_ID = GlobalUser.LoginUserInfo.user_ID, user_Pwd = txtUserPwd1.Text };
            User_Service service = new User_Service();
            bool UserID = service.UpdatePwd(vo.user_ID, vo.user_Pwd);

            if (UserID)
            {
                MessageBox.Show("비밀번호가 변경되었습니다.");
                GlobalUser.LoginUserInfo = null; // 수정완료하면 로그아웃 시켜줌
                this.DialogResult = DialogResult.No;
                this.Close();
            }
            else
            {
                MessageBox.Show("비밀번호 변경을 실패하셨습니다.");
                this.Close();
            }
        }
        #endregion

        #region 닫기버튼
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #endregion

        #region 비밀번호 라벨

        #region 비밀번호 확인 라벨컨트롤
        /// <summary>
        /// 비밀번호 확인라벨
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbx_password_Test(object sender, EventArgs e)
        {
            Regex test = new Regex("(?=.*?[a-zA-Z])(?=.*?[0-9]).{8,}");  // 영어와 숫자를 8자리이상부터 Maxlength까지
            if (test.IsMatch(((TextBox)sender).Text.Trim()))
            {
                lblPwdfail1.Visible = false;
            }
            else
            {
                lblPwdfail1.Visible = true;
            }
            if (!lblPwdfail2.Visible)
            {
                lblPwdfail2.Visible = true;
            }
        }
        #endregion

        #region 비밀번호 확인2 라벨컨트롤
        /// <summary>
        /// 입력한 비밀번호와 맞지 않으면 유효성라벨 보여줌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserPwd2_TextChanged(object sender, EventArgs e)
        {
            if (txtUserPwd1.Text.Trim() == txtUserPwd2.Text.Trim())
            {
                lblPwdfail2.Visible = false;
            }
            else
            {
                lblPwdfail2.Visible = true;
            }
        }
        #endregion

        #endregion

        #region 내정보 텍스트 이벤트
        /// <summary>
        /// 내정보의 비밀번호 텍스트 이벤트 설정
        /// </summary>
        private void SetEvent()
        {
            txtUserPwd1.KeyPress += UtilEvent.tbx_Trim;
            txtUserPwd1.KeyPress += UtilEvent.isAlphaAndDigit_KeyPress;

            txtUserPwd2.KeyPress += UtilEvent.tbx_Trim;
            txtUserPwd2.KeyPress += UtilEvent.isAlphaAndDigit_KeyPress;

            txtUserPwd1.TextChanged += tbx_password_Test;
        }
        #endregion

        #endregion


        #region 장바구니 가져오기
        private void ShowCartList()
        {
            User_Service service = new User_Service();
            List<MyCartListVO> cartList = service.GetAllMyCartList(GlobalUser.LoginUserInfo.user_ID);

            int cnt = 0;
            cartList.ForEach((item) =>
            {
                Uctrl_CartItemList cartinfo = new Uctrl_CartItemList
                {
                    MyCartInfo = item,
                    Size = new Size(855, 65),
                    Location = new Point(3, 3 + (cnt * 70)),
                    Name = item.Product_ID.ToString()
                };

                cartinfo.ThisCheck += Cartinfo_ThisCheck;
                cartinfo.DelCartList += Cartinfo_DelCartList;

                cnt++;
                pnl_Cart.Controls.Add(cartinfo);
            });
        }

        private void Cartinfo_DelCartList(object sender, Uctrl_CartItemList.CartArgs e)
        {
            User_Service service = new User_Service();
            bool result = service.DelCartList(e.CartNum);

            if (!result)
            {
                MessageBox.Show("장바구니 목록 삭제중 오류가 발생했습니다.");
                return;
            }

            List<Uctrl_CartItemList> cList = new List<Uctrl_CartItemList>();

            CommonUtil.ControlAction<Panel, Uctrl_CartItemList>(pnl_Cart, (item) =>
            {
                if (item.MyCartInfo.Cart_No != e.CartNum)
                    cList.Add(item);
            });

            pnl_Cart.Controls.Clear();

            int cnt = 0;
            cList.ForEach((item) =>
            {
                item.Location = new Point(3, 3 + (cnt * 70));
                pnl_Cart.Controls.Add(item);
                cnt++;
            });
        }

        private void Cartinfo_ThisCheck(object sender, EventArgs e)
        {
            int result = 0;

            CommonUtil.ControlAction<Panel, Uctrl_CartItemList>(pnl_Cart, (item) =>
            {
                if (item.ThisChecked)
                    result += ((int)item.MyCartInfo.Product_Price * item.Count);
            });

            lbl_TotalPrice.Text = result.ToString() + "원";
        }
        #endregion

        #region 찜목록 가져오기
        private void ShowWishList()
        {
            User_Service service = new User_Service();
            allList = service.GetAllMyWishList(GlobalUser.LoginUserInfo.user_ID); // 임시로 test2 나중에 접속한아이디로

            var list = (from item in allList
                        group item by item.Wish_NickName into grp
                        select new
                        {
                            Name = grp.Key,  // 닉네임
                            Cnt = grp.Count(),  // 물품갯수
                            tot = grp.Sum((tot) => ((int)tot.Product_Price * tot.Wish_Count)), //가격합계
                            grp // 그룹요소 
                        });

            int cnt = 0;
            foreach (var item in list)
            {
                Uctrl_WishList wish = new Uctrl_WishList
                {
                    Size = new Size(860, 70),
                    Location = new Point(3, 3 + (cnt * 75)),
                    Name = item.Name,
                    NickName = item.Name,
                    TotalItemCount = item.Cnt,
                    Price = item.tot.ToString()
                    
                };

                wish.Show_wList += Wish_Show_wList;

                foreach(var grplist in item.grp)
                {
                    if (string.IsNullOrEmpty(wish.FstItem))
                        wish.FstItem = grplist.Product_Name;

                    wish.WishItem = grplist;
                }

                //foreach (var grplist in item.grp)
                //{
                //    if (string.IsNullOrEmpty(wish.FstItem))
                //        wish.FstItem = grplist.Product_Name; // 첫번째 물품만 반환

                //    wish.WishItem = grplist;
                //}

                pnl_WishList.Controls.Add(wish);

                cnt++;
            }
        }

        private void Wish_Show_wList(object sender, Uctrl_WishList.ListArgs<MyWishInfoVO> args)
        {
            UC_ShowItemList si = new UC_ShowItemList();
            si.Location = new Point(32, 41);
            si.Size = new Size(814, 400);
            si.Name = "wishlist";
            si.List = args.ItemList;
            si.ThisType = UC_ShowItemList.UC_Type.Wish;
            si.ThisClose += Si_ThisClose;

            pnl_WishList.Controls.Add(si);

            si.BringToFront();
        }

        private void Si_ThisClose(object sender, EventArgs e)
        {
            ((Panel)((Control)sender).Parent).Controls.Remove((Control)sender);
        }
        #endregion

        #region 장바구니로 보내기
        private void btn_SendCartList_Click(object sender, EventArgs e)
        {
            List<MyWishInfoVO> checkList = new List<MyWishInfoVO>();
            CommonUtil.ControlAction<Panel, Uctrl_WishList>(pnl_WishList, (item) =>
            {
                if (item.ThisChecked)
                {
                    checkList.AddRange(item.MyWishList);
                }
            });

            User_Service service = new User_Service();
            bool result = service.SendCartList(checkList, GlobalUser.LoginUserInfo.user_ID); //임시로 test2아이디로 설정

            if (result)
                MessageBox.Show("장바구니로 옮겼습니다.");
            else
                MessageBox.Show("오류");

            DeleteWishItem();

            pnl_Cart.Controls.Clear();
            ShowCartList();

            //RefreshList(pnl_Cart, "ShowCartList");
        }

        #endregion

        #region 찜목록 삭제
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            List<int> delWishList = DeleteWishItem();

            User_Service service = new User_Service();
            bool result = service.DelWishList(delWishList);


            if (result)
                MessageBox.Show("선택한 찜목록을 삭제했습니다");
            else
                MessageBox.Show("찜목록 삭제 오류");

        }

        private List<int> DeleteWishItem()
        {
            List<int> delWishList = new List<int>();
            List<Uctrl_WishList> wList = new List<Uctrl_WishList>();

            CommonUtil.ControlAction<Panel, Uctrl_WishList>(pnl_WishList, (selectitem) =>
            {
                if (selectitem.ThisChecked)
                    delWishList.Add(selectitem.Wish_No);
                else
                    wList.Add(selectitem);
            });

            pnl_WishList.Controls.Clear();

            int cnt = 0;
            wList.ForEach((item) =>
            {
                item.Location = new Point(3, 3 + (cnt * 75));
                pnl_WishList.Controls.Add(item);
                cnt++;
            });
            return delWishList;
        }
        #endregion

        #region 거래내역 가져오기
        public void ShowPurchaseList()
        {
            User_Service service = new User_Service();
            List<MyPurchaseInfoVO> allPurchase = service.GetMyPurchaseList(GlobalUser.LoginUserInfo.user_ID);

            var list = (from item in allPurchase
                        group item by item.Purchase_Date into grp
                        select new
                        {
                            Name = grp.Key.ToString("yyyy-MM-dd일 주문"),
                            Cnt = grp.Count(),
                            grp
                        });

            int cnt = 0;
            foreach (var item in list)
            {
                Uctrl_WishList purchase = new Uctrl_WishList
                {
                    Size = new Size(860, 70),
                    Location = new Point(3, 3 + (cnt * 75)),
                    Name = item.Name,
                    NickName = item.Name,
                    TotalItemCount = item.Cnt, 
                    ThisType = Uctrl_WishList.UC_Type.Purchase
                };

                foreach (var grpitem in item.grp)
                {
                    if (string.IsNullOrEmpty(purchase.FstItem))
                    {
                        purchase.FstItem = grpitem.Product_Name;
                        purchase.Price = grpitem.Purchase_State; // 배송상태
                    }

                    purchase.PurchaseItem = grpitem;
                }

                purchase.Show_pList += Purchase_Show_pList;
                pnl_Purchase.Controls.Add(purchase);

                cnt++;
            }
        }

        private void Purchase_Show_pList(object sender, Uctrl_WishList.ListArgs<MyPurchaseInfoVO> args)
        {
            UC_ShowItemList si = new UC_ShowItemList();
            si.Location = new Point(32, 41);
            si.Size = new Size(814, 400);
            si.Name = "purchaseList";
            si.List = args.ItemList;
            si.ThisType = UC_ShowItemList.UC_Type.Purchase;
            si.ThisClose += Si_ThisClose;

            pnl_Purchase.Controls.Add(si);

            si.BringToFront();
        }
        #endregion


        private void btnBuy_Click(object sender, EventArgs e)
        {
            List<MyCartListVO> checkList = new List<MyCartListVO>();

            CommonUtil.ControlAction<Panel, Uctrl_CartItemList>(pnl_Cart, (item) =>
            {
                if (item.ThisChecked)
                {
                    checkList.Add(item.MyCartInfo);
                }
            });

            frmPurchase frm = new frmPurchase(checkList);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                pnl_Cart.Controls.Clear();
                pnl_Purchase.Controls.Clear();

                ShowCartList();
                ShowPurchaseList();
            }
        }

        private void cbx_AllCheck_CheckedChanged(object sender, EventArgs e)
        {
            CommonUtil.ControlAction<Panel, Uctrl_CartItemList>(pnl_Cart, (item) =>
            {
                item.ThisChecked = cbx_AllCheck.Checked;
            });
        }

    }
}
