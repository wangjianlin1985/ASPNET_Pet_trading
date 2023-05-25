using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ENTITY
{
    /// <summary>
    ///ProductSell ��ժҪ˵�����������ʵ��
    /// </summary>

    public class ProductSell
    {
        /*����id*/
        private int _sellId;
        public int sellId
        {
            get { return _sellId; }
            set { _sellId = value; }
        }

        /*��������*/
        private string _productName;
        public string productName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        /*�������*/
        private int _productClassObj;
        public int productClassObj
        {
            get { return _productClassObj; }
            set { _productClassObj = value; }
        }

        /*������ͼ*/
        private string _productPhoto;
        public string productPhoto
        {
            get { return _productPhoto; }
            set { _productPhoto = value; }
        }

        /*���ۼ۸�*/
        private float _sellPrice;
        public float sellPrice
        {
            get { return _sellPrice; }
            set { _sellPrice = value; }
        }

        /*���������*/
        private int _xjcdObj;
        public int xjcdObj
        {
            get { return _xjcdObj; }
            set { _xjcdObj = value; }
        }

        /*����˵��*/
        private string _sellDesc;
        public string sellDesc
        {
            get { return _sellDesc; }
            set { _sellDesc = value; }
        }

        /*�����û�*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*����ʱ��*/
        private DateTime _addTime;
        public DateTime addTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }

    }
}
