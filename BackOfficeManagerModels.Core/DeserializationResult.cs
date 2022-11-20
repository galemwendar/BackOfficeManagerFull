namespace BackOfficeManagerModels.Core
{
    /// <summary>
    /// ����� �������� ��������� �������������� xml ������ ServerProperties
    /// </summary>


    // ����������. ��� ������� ���������� ���� ����� ������������� NET Framework ������ 4.5 ��� ����� ������� ������ � .NET Core ��� Standard ������ 2.0 ��� ����� �������.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class r
    {

        public string serverNameField;

        public string editionField;

        public string versionField;

        public string computerNameField;

        public string serverStateField;

        public rProtocol protocolField;

        public rServerAddr serverAddrField;

        public rServerSubUrl serverSubUrlField;

        public byte portField;

        public bool isPresentField;

        /// <remarks/>
        public string serverName
        {
            get
            {
                return this.serverNameField;
            }
            set
            {
                this.serverNameField = value;
            }
        }

        /// <remarks/>
        public string edition
        {
            get
            {
                return this.editionField;
            }
            set
            {
                this.editionField = value;
            }
        }

        /// <remarks/>
        public string version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <remarks/>
        public string computerName
        {
            get
            {
                return this.computerNameField;
            }
            set
            {
                this.computerNameField = value;
            }
        }

        /// <remarks/>
        public string serverState
        {
            get
            {
                return this.serverStateField;
            }
            set
            {
                this.serverStateField = value;
            }
        }

        /// <remarks/>
        public rProtocol protocol
        {
            get
            {
                return this.protocolField;
            }
            set
            {
                this.protocolField = value;
            }
        }

        /// <remarks/>
        public rServerAddr serverAddr
        {
            get
            {
                return this.serverAddrField;
            }
            set
            {
                this.serverAddrField = value;
            }
        }

        /// <remarks/>
        public rServerSubUrl serverSubUrl
        {
            get
            {
                return this.serverSubUrlField;
            }
            set
            {
                this.serverSubUrlField = value;
            }
        }

        /// <remarks/>
        public byte port
        {
            get
            {
                return this.portField;
            }
            set
            {
                this.portField = value;
            }
        }

        /// <remarks/>
        public bool isPresent
        {
            get
            {
                return this.isPresentField;
            }
            set
            {
                this.isPresentField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class rProtocol
    {

        private byte nullField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte @null
        {
            get
            {
                return this.nullField;
            }
            set
            {
                this.nullField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class rServerAddr
    {

        private byte nullField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte @null
        {
            get
            {
                return this.nullField;
            }
            set
            {
                this.nullField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class rServerSubUrl
    {

        private byte nullField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte @null
        {
            get
            {
                return this.nullField;
            }
            set
            {
                this.nullField = value;
            }
        }
    }

}