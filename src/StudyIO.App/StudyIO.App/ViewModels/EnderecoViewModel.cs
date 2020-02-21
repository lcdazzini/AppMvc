using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace StudyIO.App.ViewModels
{
	public class EnderecoViewModel
	{
		[Key]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		[StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
		public string Logradouro { get; set; }

		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		public int Numero { get; set; }

		public string Complemento { get; set; }
		
		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		[StringLength(8, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 8)]
		public string Cep { get; set; }

		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		[StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 8)]
		public string Bairro { get; set; }

		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		[StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
		public string Cidade { get; set; }

		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		[StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
		public string Estado { get; set; }

		[HiddenInput]
		public Guid FornecedorId { get; set; }
	}
}
