using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace qualyteam.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        [Required(ErrorMessage = "O Código é obrigatório!")]
        [Range(1,double.MaxValue,ErrorMessage ="O Código deve ser maior que 0!")]
        public int Codigo { get; set; }

        [BindProperty]
        [Required(ErrorMessage="O título é obrigatório!")]
        public string Titulo { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "A categoria é obrigatória!")]
        public string Categoria { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Selecione um processo !")]
        public string? ProcessoSelecionado { get; set; }


        [BindProperty]
        public List<SelectListItem> Processos { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Selecione um arquivo!")]
        public IFormFile Arquivo { get; set; }

        public string MensagemErro { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            Processos= new List<SelectListItem>();
           var processo1=new SelectListItem
           {
               Value = "Processo 1",
               Text = "Processo 1"
           };
            Processos.Add(processo1);

            var processo2 = new SelectListItem
            {
                Value = "Processo 2",
                Text = "Processo 2"
            };
            Processos.Add(processo2);

            var processo3 = new SelectListItem
            {
                Value = "Processo 3",
                Text = "Processo 3"
            };
            Processos.Add(processo3);
            ProcessoSelecionado = null;
        }

        public void OnGet()
        {
          

        }
        public void OnPost()
        {
            var nomearquivo = Arquivo.FileName;
            var extensaoarquivo=Path.GetExtension(nomearquivo);
            extensaoarquivo=extensaoarquivo.ToLower();
            if(extensaoarquivo!=".pdf" && extensaoarquivo!=".doc" && extensaoarquivo!=".xls" && extensaoarquivo!=".docx" && extensaoarquivo!=".xlsx")
            {
                var msg = new StringBuilder();
                msg.AppendLine("Tipo de Arquivo Inválido. Tipos de arquivos permitidos: PDF, DOC, XLS, DOCX e XLSX.");
                msg.AppendLine("Nenhum dado foi gravado.");
                MensagemErro = msg.ToString();
             
            }
            if(string.IsNullOrEmpty(ProcessoSelecionado))
            {
                MensagemErro = "Selecione um Processo";
            }
        }
    }
}