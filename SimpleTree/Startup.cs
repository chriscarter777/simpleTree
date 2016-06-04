using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleTree.Startup))]
namespace SimpleTree
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
        }
    }
}
