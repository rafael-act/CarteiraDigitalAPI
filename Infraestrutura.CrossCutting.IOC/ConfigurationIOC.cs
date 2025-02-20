using Aplicacao.Interface;
using Aplicacao.Servico;
using Autofac;
using Dominio.Core.Interfaces.Repositorios;
using Dominio.Core.Interfaces.Servicos;
using Dominio.Core.Interfaces.UnitOfWork;
using Dominio.Servico.Servico;
using Infraestrutura.CrossCutting.Adapter.Map;
using Infraestrutura.Repositorio;
using Infraestrutura.Repositorio.UnitOfWork;
using Infrastrutura.CrossCutting.Adapter.Interfaces;

namespace Infraestrutura.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AplicacaoServicoCliente>().As<IAplicacaoServicoCliente>();
            builder.RegisterType<AplicacaoServicoCarteira>().As<IAplicacaoServicoCarteira>();
            builder.RegisterType<AplicacaoServicoTransacao>().As<IAplicacaoServicoTransacao>();
          
            
            builder.RegisterType<ServicoCliente>().As<IServicoCliente>();
            builder.RegisterType<ServicoCarteira>().As<IServicoCarteira>();
            builder.RegisterType<ServicoTransacao>().As<IServicoTransacao>();


            builder.RegisterType<RepositorioCliente>().As<IRepositorioCliente>();
            builder.RegisterType<RepositorioCarteira>().As<IRepositorioCarteira>();
            builder.RegisterType<RepositorioTransacao>().As<IRepositorioTransacao>();


            builder.RegisterType<MapperCliente>().As<IMapperCliente>();
            builder.RegisterType<MapperCarteira>().As<IMapperCarteira>();
            builder.RegisterType<MapperTransacao>().As<IMapperTransacao>();
            
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

        }
    }
}