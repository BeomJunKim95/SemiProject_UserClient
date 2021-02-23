using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamProject
{
    public static class ExtenstionMethod
    {

        #region 데이터테이블 로우 추가
        /// <summary>
        /// 데이터테이블의 로우를 추가해줌
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DataRow insertRow(this DataTable dt)
        {
            DataRow row= dt.NewRow();
            dt.Rows.InsertAt(row, 0);
            return row;
        }
        #endregion

        #region SQL 파라미터 설정
        /// <summary>
        /// SQL 파라미터에 값 타입과 값을 설정해줌
        /// </summary>
        /// <param name="cmd">SqlCommand</param>
        /// <param name="type">데이터타입</param>
        /// <param name="ParamName">컬럼명</param>
        /// <param name="ParamValue">값</param>
        public static void setParameters(this SqlCommand cmd, SqlDbType type, string ParamName, string ParamValue)
        {
            cmd.Parameters.Add(ParamName, type);
            cmd.Parameters[ParamName].Value = ParamValue;
        }
        #endregion

        #region 폼 열기
        /// <summary>
        /// 입력받은 폼을 열어줌
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="MdiParent">폼이름</param>
        public static void OpenCreateForm<T>(this Form MdiParent) where T : Form, new() // where은 T의 조건, where은 Form을 상속받으면서, new를 할수있어야된다. 확장메서드
        {
            foreach (Form form in Application.OpenForms) // 열려있는 폼들중에 하나를 꺼냄
            {
                if (form.GetType() == typeof(T)) // form의 타입이 열려고하는거랑 타입이 같은지
                {
                    form.Activate(); // 폼 활성화
                    return;
                }
            }

            T frm = new T();
            frm.MdiParent = MdiParent; // 폼의 Mdi를 설정
            frm.Show(); // 폼 열기
        }
        #endregion
    }
}
