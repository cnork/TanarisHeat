namespace UserApi.Interfaces
{
    public interface IPlugin
    {
        #region Properties

        string Name
        {
            get;
        }

        string Description
        {
            get;
        }

        string Version
        {
            get;
        }

        Enums.PluginType PluginType
        {
            get;
        }

        #endregion

        #region Methods

        void OpenForm();
        void Pulse();
        void Close();

        #endregion
    }
}
