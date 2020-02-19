using AutoMapper;
using StudyIO.App.ViewModels;
using StudyIO.Business.Models;

namespace StudyIO.App.AutoMapper
{
	public class AutoMapperConfig : Profile
	{
		public AutoMapperConfig()
		{
			// CreateMap faz a configuração do domínio para viewmodel
			// ReverseMap faz a configuração da viewmodel para domínio

			CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
			CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
			CreateMap<Produto, ProdutoViewModel>().ReverseMap();
		}
	}
}
