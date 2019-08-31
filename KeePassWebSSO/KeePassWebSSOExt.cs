using KeePass.Plugins;

namespace KeePassWebSSO {
    public class KeePassWebSSOExt : Plugin {
        private SSOWebRequestCreator m_requestCreator;

        public override bool Initialize(IPluginHost host) {
            this.m_requestCreator = new SSOWebRequestCreator();
            this.m_requestCreator.Register();
            return true;
        }
    }
}
