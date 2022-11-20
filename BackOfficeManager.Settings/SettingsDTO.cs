namespace BackOfficeManager.Settings
{


    // ����������. ��� ������� ���������� ���� ����� ������������� NET Framework ������ 4.5 ��� ����� ������� ������ � .NET Core ��� Standard ������ 2.0 ��� ����� �������.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class settings
    {

        private settingsUser userField;

        private object pathToFolderField;

        /// <remarks/>
        public settingsUser User
        {
            get
            {
                return this.userField;
            }
            set
            {
                this.userField = value;
            }
        }

        /// <remarks/>
        public object PathToFolder
        {
            get
            {
                return this.pathToFolderField;
            }
            set
            {
                this.pathToFolderField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class settingsUser
    {

        private object loginField;

        private object passwordField;

        /// <remarks/>
        public object Login
        {
            get
            {
                return this.loginField;
            }
            set
            {
                this.loginField = value;
            }
        }

        /// <remarks/>
        public object Password
        {
            get
            {
                return this.passwordField;
            }
            set
            {
                this.passwordField = value;
            }
        }
    }
}

