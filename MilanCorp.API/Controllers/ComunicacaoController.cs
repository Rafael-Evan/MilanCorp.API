using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilanCorp.Repository;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MilanCorp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ComunicacaoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ComunicacaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("PortasAbertas")]
        public async Task<ActionResult> PortasAbertas(string finalidade, string mensagem)
        {
            MailMessage objEmail = new MailMessage();

            //rementente do email
            objEmail.From = new MailAddress("comunicacao@milanleiloes.com.br");

            //destinatário(s) do email(s)
            objEmail.To.Add("eduardo.raposo@milanleiloes.com.br");
            objEmail.To.Add("luis.piva@milanleiloes.com.br");
            objEmail.To.Add("rafael.milan@milanleiloes.com.br");

            //prioridade do email
            objEmail.Priority = MailPriority.High;

            //utilize true pra ativar html no conteúdo do email, ou false, para somente texto
            objEmail.IsBodyHtml = true;

            //Assunto do email
            objEmail.Subject = "Sugestão de um colaborador";

            //corpo do email a ser enviado
            objEmail.Body = "<!DOCTYPE html PUBLIC -//W3C//DTD XHTML 1.0 Transitional//EN http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd><html><head><meta charset=UTF-8><meta content=width=device-width, initial-scale=1 name=viewport><meta name=x-apple-disable-message-reformatting><meta http-equiv=X-UA-Compatible content=IE=edge><meta content=telephone=no name=format-detection><title></title> <!--[if (mso 16)]><style type=text/css>a{text-decoration:none}</style><![endif]--> <!--[if gte mso 9]><style>sup{font-size:100% !important}</style><![endif]--> <!--[if !mso]><!-- --><link href=https://fonts.googleapis.com/css?family=Lato:400,400i,700,700i rel=stylesheet> <!--<![endif]--></head><body><div class=es-wrapper-color> <!--[if gte mso 9]> <v:background xmlns:v=urn:schemas-microsoft-com:vml fill=t> <v:fill type=tile color=#f4f4f4></v:fill> </v:background> <![endif]--><table class=es-wrapper width=100% cellspacing=0 cellpadding=0><tbody><tr class=gmail-fix height=0><td><table width=600 cellspacing=0 cellpadding=0 border=0 align=center><tbody><tr><td cellpadding=0 cellspacing=0 border=0 style=line-height: 1px; min-width: 600px; height=0><img src=https://esputnik.com/repository/applications/images/blank.gif style=display: block; max-height: 0px; min-height: 0px; min-width: 600px; width: 600px; alt width=600 height=1></td></tr></tbody></table></td></tr><tr><td class=esd-email-paddings valign=top><table class=es-content esd-header-popover cellspacing=0 cellpadding=0 align=center><tbody><tr></tr><tr><td class=esd-stripe esd-custom-block-id=7962 align=center><table class=es-content-body style=background-color: transparent; width=600 cellspacing=0 cellpadding=0 align=center><tbody><tr><td class=esd-structure es-p15t es-p15b es-p10r es-p10l align=left> <!--[if mso]><table width=580 cellpadding=0 cellspacing=0><tr><td width=282 valign=top><![endif]--><table class=es-left cellspacing=0 cellpadding=0 align=left><tbody><tr><td class=esd-container-frame width=282 align=left><table width=100% cellspacing=0 cellpadding=0><tbody><tr><td align=center class=esd-empty-container style=display: none;></td></tr></tbody></table></td></tr></tbody></table> <!--[if mso]></td><td width=20></td><td width=278 valign=top><![endif]--><table class=es-right cellspacing=0 cellpadding=0 align=right><tbody><tr><td class=esd-container-frame width=278 align=left><table width=100% cellspacing=0 cellpadding=0><tbody><tr><td align=center class=esd-empty-container style=display: none;></td></tr></tbody></table></td></tr></tbody></table> <!--[if mso]></td></tr></table><![endif]--></td></tr></tbody></table></td></tr></tbody></table><table class=es-header es-visible-amp-html-only cellspacing=0 cellpadding=0 align=center><tbody><tr><td class=esd-stripe esd-custom-block-id=6339 align=center bgcolor=#b8ced2 style=background-color: rgb(184, 206, 210);><table class=es-header-body width=600 cellspacing=0 cellpadding=0 align=center><tbody><tr><td class=esd-structure es-p20t es-p10b es-p10r es-p10l align=left><table width=100% cellspacing=0 cellpadding=0><tbody><tr><td class=esd-container-frame width=580 valign=top align=center><table width=100% cellspacing=0 cellpadding=0><tbody><tr><td align=center class=esd-block-image><a target=_blank><img class=adapt-img src=https://i.ibb.co/JHsn0fW/milanx.png alt style=display: block; width=279></a></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table><table class=es-content cellspacing=0 cellpadding=0 align=center><tbody><tr><td class=esd-stripe style=background-color: rgb(184, 206, 210); esd-custom-block-id=6340 bgcolor=#b8ced2 align=center><table class=es-content-body style=background-color: transparent; width=600 cellspacing=0 cellpadding=0 align=center><tbody><tr><td class=esd-structure align=left><table width=100% cellspacing=0 cellpadding=0><tbody><tr><td class=esd-container-frame width=600 valign=top align=center><table style=background-color: rgb(255, 255, 255); border-radius: 4px; border-collapse: separate; width=100% cellspacing=0 cellpadding=0 bgcolor=#ffffff><tbody><tr><td class=esd-block-text es-p35t es-p5b es-p30r es-p30l align=center><h1>Sugestão de um colaborador!</h1></td></tr><tr><td class=esd-block-spacer es-p5t es-p5b es-p20r es-p20l bgcolor=#ffffff align=center><table width=100% height=100% cellspacing=0 cellpadding=0 border=0><tbody><tr><td style=border-bottom: 1px solid rgb(255, 255, 255); background: rgba(0, 0, 0, 0) none repeat scroll 0% 0%; height: 1px; width: 100%; margin: 0px;></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table><table class=es-content cellspacing=0 cellpadding=0 align=center><tbody><tr><td class=esd-stripe align=center><table class=es-content-body style=background-color: transparent; width=600 cellspacing=0 cellpadding=0 align=center><tbody><tr><td class=esd-structure align=left><table width=100% cellspacing=0 cellpadding=0><tbody><tr><td class=esd-container-frame width=600 valign=top align=center><table style=border-radius: 4px; border-collapse: separate; background-color: rgb(255, 255, 255); width=100% cellspacing=0 cellpadding=0 bgcolor=#ffffff><tbody><tr><td bgcolor=#ffffff align=left class=esd-block-text es-m-txt-l es-p20t es-p25b es-p25r es-p25l><h2 style=color: #220201;><br></h2><p style=color: #220201;><span style=font-size:20px;>Finalidade</span>: <span style=font-size:20px;>" + finalidade + "</span></p></td></tr><tr><td class=esd-block-text es-m-txt-l es-p20 align=left bgcolor=#fefafa><p style=color: #220201;><span style=font-size:20px;>Mensagem</span>: <span style=font-size:20px;>" + mensagem + " </span></p><p style=color: #040404;><br></p><p style=color: #040404;><br></p><p style=color: #040404;><br></p><p style=color: #040404;><br></p></td></tr><tr><td class=esd-block-text es-p20t es-p30r es-p30l es-m-txt-l align=left><p><br></p></td></tr><tr><td align=center class=esd-block-spacer es-p20><table border=0 width=100% height=100% cellpadding=0 cellspacing=0><tbody><tr><td style=border-bottom: 1px solid #cccccc; background:none; height:1px; width:100%; margin:0px 0px 0px 0px;></td></tr></tbody></table></td></tr><tr><td align=center class=esd-block-text><p style=font-size: 12px;>&nbsp; R. Quatá, 733 - Vila Olímpia, São Paulo - SP, 04546-044</p></td></tr><tr><td align=center class=esd-block-social es-p10t es-p5b es-p20r><table cellpadding=0 cellspacing=0 class=es-table-not-adapt es-social><tbody><tr><td align=center valign=top esd-tmp-icon-type=Facebook class=es-p10r><a target=_blank href=https://www.facebook.com/milanleiloes/><img src=https://stripo.email/static/assets/img/social-icons/circle-black/facebook-circle-black.png alt=Fb title=Facebook width=32></a></td><td align=center valign=top esd-tmp-icon-type=instagram><a target=_blank href=https://www.instagram.com/milanleiloes/?hl=pt-br><img src=https://stripo.email/static/assets/img/social-icons/circle-black/instagram-circle-black.png alt=Ig title=Instagram width=32></a></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table><table class=es-content cellspacing=0 cellpadding=0 align=center><tbody><tr><td class=esd-stripe align=center><table class=es-content-body style=background-color: transparent; width=600 cellspacing=0 cellpadding=0 align=center><tbody><tr><td class=esd-structure align=left><table width=100% cellspacing=0 cellpadding=0><tbody><tr><td class=esd-container-frame width=600 valign=top align=center><table width=100% cellspacing=0 cellpadding=0><tbody><tr><td class=esd-block-spacer es-p10t es-p20b es-p20r es-p20l align=center><table width=100% height=100% cellspacing=0 cellpadding=0 border=0><tbody><tr><td style=border-bottom: 1px solid rgb(244, 244, 244); background: rgba(0, 0, 0, 0) none repeat scroll 0% 0%; height: 1px; width: 100%; margin: 0px;></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table><table class=es-content cellspacing=0 cellpadding=0 align=center><tbody><tr><td class=esd-stripe esd-custom-block-id=6341 align=center><table class=es-content-body style=background-color: transparent; width=600 cellspacing=0 cellpadding=0 align=center><tbody><tr><td class=esd-structure align=left><table width=100% cellspacing=0 cellpadding=0><tbody><tr><td class=esd-container-frame width=600 valign=top align=center><table style=background-color: rgb(255, 236, 209); border-radius: 4px; border-collapse: separate; width=100% cellspacing=0 cellpadding=0 bgcolor=#ffecd1><tbody><tr><td align=center class=esd-empty-container style=display: none;></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table><table class=es-footer cellspacing=0 cellpadding=0 align=center><tbody><tr><td class=esd-stripe esd-custom-block-id=6342 align=center><table class=es-footer-body width=600 cellspacing=0 cellpadding=0 align=center><tbody><tr><td class=esd-structure es-p30t es-p30b es-p30r es-p30l align=left><table width=100% cellspacing=0 cellpadding=0><tbody><tr><td class=esd-container-frame width=540 valign=top align=center><table width=100% cellspacing=0 cellpadding=0><tbody><tr><td align=center class=esd-empty-container style=display: none;></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table><table class=esd-footer-popover es-content cellspacing=0 cellpadding=0 align=center><tbody><tr><td class=esd-stripe align=center><table class=es-content-body style=background-color: transparent; width=600 cellspacing=0 cellpadding=0 align=center><tbody><tr><td class=esd-structure es-p30t es-p30b es-p20r es-p20l align=left><table width=100% cellspacing=0 cellpadding=0><tbody><tr><td class=esd-container-frame width=560 valign=top align=center><table width=100% cellspacing=0 cellpadding=0><tbody><tr><td align=center class=esd-empty-container style=display: none;></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></div></body></html>";


            //"<img src =https://i.ibb.co/JHsn0fW/milanx.png align=center alt =milanx border =0 face height=50 width=100>"
            // + ("<hr style=height: 2px; border: none; color:#000; background-color:#000; margin-top: 0px; margin-bottom: 0px;/><br/>"
            // + "<b>Finalidade</b>: " + finalidade + "<br/>"
            // + "<b>Mensagem</b>: " + mensagem).ToUpper();

            //codificação do assunto do email para que os caracteres acentuados serem reconhecidos.
            objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");

            //codificação do corpo do emailpara que os caracteres acentuados serem reconhecidos.
            objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

            //cria o objeto responsável pelo envio do email
            SmtpClient objSmtp = new SmtpClient();

            //endereço do servidor SMTP(para mais detalhes leia abaixo do código)
            objSmtp.Host = "smtp.gmail.com";
            objSmtp.Port = 587;
            objSmtp.EnableSsl = true;

            //para envio de email autenticado, coloque login e senha de seu servidor de email
            objSmtp.Credentials = new NetworkCredential("comunicacao@milanleiloes.com.br", "M1l@n19Com1");

            //envia o email
            objSmtp.Send(objEmail);

            return Ok();
        }
    }
}
