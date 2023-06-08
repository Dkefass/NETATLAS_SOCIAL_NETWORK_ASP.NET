using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetAtlas.Models;
using NetAtlas.Views;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace NetAtlas.Controllers
{
    public class CreateCompteController : Controller
    {

        
        private NetAtlasDbContext db = new NetAtlasDbContext();

        public IActionResult Ajouter()
        {
            return View();
        }

        public IActionResult Ajouter (string email,string id)
        {

            var Membre = db.Membre.ToList();
            var membre = Membre.Find(a => a.email == email);
            ViewBag.Membre = membre;
            ListeAmis m = new ListeAmis();


            m.date_amitie = DateTime.Now;
          
            m.email_amis = id;
            m.Membres_mail = email;

            db.ListeAmis.Add(m);
            db.SaveChanges();

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ChatRoomR( string id,string Membresearch)

        {

            var Membre = db.Membre.ToList();
            var membre = Membre.Find(a => a.email == id);
            ViewBag.Membre = membre;    

            ViewData["GetMembreDetails"] = Membresearch;
            var Membrequery = from x in db.Membre select x;
            if (!String.IsNullOrEmpty(Membresearch))
            {
                Membrequery = Membrequery.Where(x => (x.email.Contains(Membresearch) || x.sexe.Contains(Membresearch) || x.prenom.Contains(Membresearch) || x.mot_de_passe.Contains(Membresearch) || x.nom.Contains(Membresearch)) && x.statut != "Guest" && x.statut != "admin");
            }
            return View(await Membrequery.AsNoTracking().ToListAsync());
        }

        // GET: InscriptionController
        [HttpGet]
        public async Task<IActionResult> ListeMembresR(string Membresearch)
        {
            ViewData["GetMembreDetails"] = Membresearch;
            var Membrequery = from x in db.Membre select x;
            if (!String.IsNullOrEmpty(Membresearch))
            {
               Membrequery = Membrequery.Where(x => (x.email.Contains(Membresearch) || x.sexe.Contains(Membresearch) || x.prenom.Contains(Membresearch) || x.mot_de_passe.Contains(Membresearch) || x.nom.Contains(Membresearch) ) && x.statut=="Guest");
            }
            return View(await Membrequery.AsNoTracking().ToListAsync());
        }


        [HttpGet]
        public async Task<IActionResult> ListeMembresAcceptMR(string Membresearch)
        {
            ViewData["GetMembreDetails"] = Membresearch;
            var Membrequery = from x in db.Membre select x;
            if (!String.IsNullOrEmpty(Membresearch))
            {
                Membrequery = Membrequery.Where(x => x.email.Contains(Membresearch) || x.sexe.Contains(Membresearch) || x.prenom.Contains(Membresearch) || x.mot_de_passe.Contains(Membresearch) || x.nom.Contains(Membresearch) || x.statut.Contains(Membresearch) &&( x.statut == "Guest Accepte" || x.statut == "Moderateur") );
            }
            return View(await Membrequery.AsNoTracking().ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> ListeMembresAcceptR(string Membresearch)
        {
            ViewData["GetMembreDetails"] = Membresearch ;
            var Membrequery = from x in db.Membre select x;
            if(!String.IsNullOrEmpty(Membresearch))
            {
                Membrequery = Membrequery.Where(x => x.email.Contains(Membresearch) || x.sexe.Contains(Membresearch) || x.prenom.Contains(Membresearch) || x.mot_de_passe.Contains(Membresearch) || x.nom.Contains(Membresearch) || x.statut.Contains(Membresearch) &&( x.statut == "Guest Accepte" || x.statut == "Moderateur") );
            }
            return View(await Membrequery.AsNoTracking().ToListAsync());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminEspace(LoginVM ob)
        {
            
            var Membre = db.Membre.ToList();
            var membre = Membre.Find(a => a.email ==ob.email);

            bool EmailExiste2 = db.Membre.Any(x => x.mot_de_passe == ob.mot_de_passe);
            bool EmailExiste3 = db.Membre.Any(y => y.email == ob.email);

            if (EmailExiste2 && EmailExiste3 && membre.statut == "admin")
            {
                return View(membre);
            }
           
            return RedirectToAction("AdminError"); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModerateurEspace(LoginVM ob)
        {

            var Membre = db.Membre.ToList();
            var membre = Membre.Find(a => a.email == ob.email);

            bool EmailExiste2 = db.Membre.Any(x => x.mot_de_passe == ob.mot_de_passe);
            bool EmailExiste3 = db.Membre.Any(y => y.email == ob.email);

            if (EmailExiste2 && EmailExiste3 && membre.statut == "Moderateur")
            {
                return View(membre);
            }

            return RedirectToAction("ModerateurError");
        }


        public ActionResult ChatRoomR()
        {
            return View();
        }
        public ActionResult ModerateurEspace()
        {
            return View();
        }

        public ActionResult Moderateur()
        {
            return View();
        }

       
        public ActionResult AdminEspace()
        {
            return View();
        }
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult AdminError()
        {
            ViewBag.EmailMessage2 = "Adresse Email  ou Mot de passe non valide";
            return View();
        }
        public ActionResult ModerateurError()
        {
            ViewBag.EmailMessage2 = "Adresse Email  ou Mot de passe non valide";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult AddPhotoVideo()
        {
            return View();
        }

        public ActionResult ValiderMembreError()
        {
            return View();
        }


        public ActionResult ValiderMembre(string id)
        {
           
        

          
            var Membre = db.Membre.ToList();
            var membre1 = Membre.Find(a => a.email == id);
            var membre2 = Membre.Find(a => a.email == id);

            MailMessage mail_n = new MailMessage();
            mail_n.To.Add(id);
            mail_n.From = new MailAddress("netatlas0@gmail.com");
            mail_n.Subject = "VALIDATION DE COMPTE";

            string Body  ="<h1> SALUT! " + membre2.nom+" "+membre2.prenom+" VOUS AVEZ ETE ACCEPTE SUR NETATLAS <br> VOUS POUVEZ VOUS CONNECTER A PRESENT";
            mail_n.Body = Body;

            mail_n.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("netatlas0@gmail.com", "netatlas1234");
            //Or your Smtp Email ID and Password
            smtp.EnableSsl = true;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtp.Send(mail_n);

            var email = membre2.email;
            membre2.statut = "Guest Accepte";
            db.Membre.Remove(membre1);
            db.SaveChanges();
            db.Membre.Add(membre2);
            db.SaveChanges();
           



            return View();
        }

        public ActionResult DeleteMembre(string id)
        {
            var Membre = db.Membre.ToList();
            var membred = Membre.Find(a => a.email == id);
            db.Membre.Remove(membred);
            db.SaveChanges();

            return View();
        }

        public ActionResult ListeMembresAccept()

        {
            var Membre = db.Membre.Where(a => a.statut == "Guest Accepte" || a.statut == "Moderateur").ToList();
            return View(Membre);
        }
        public ActionResult ListeMembresAcceptM()

        {
            var Membre = db.Membre.Where(a => a.statut == "Guest Accepte" || a.statut == "Moderateur").ToList();
           
                return View(Membre);
        }



        public ActionResult ListeMembres()

        {
            var Membre = db.Membre.Where(a=> a.statut=="Guest").ToList();
            return View(Membre);
        }

        public ActionResult UnMembre(string id)
        {
            var Membre = db.Membre.ToList();
            var membre = Membre.Find(a => a.email == id);
            if (membre.image_url == " ")
            {
                var newmembre = membre;
                newmembre.image_url = "Capture d’écran 2022-03-15 à 18.45.14.png";
              return View(newmembre);
            }

            return View(membre);
         }
        public ActionResult UnMembreM(string id)
        {
            var Membre = db.Membre.ToList();
            var membre = Membre.Find(a => a.email == id);

            return View(membre);
        }



        public ActionResult Index()
        {
            return View();
        }

        // GET: InscriptionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InscriptionController/Create
        [HttpGet]
        public ActionResult CreateCompte()
        {
            return View();
        }



        // POST: InscriptionController/Create



        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCompte(InscriptionVM obj)
        {

            bool EmailExiste = db.Membre.Any(x => x.email == obj.email) ;

            if(EmailExiste)
            {
                ViewBag.EmailMessage = " Cette adresse email est déjá enrégistré";
                     return View();
            }
            if(Request.Form["sexe"] == "Masculin")
            {
                Membre m = new Membre();

                m.email = obj.email;
                m.prenom = obj.prenom;
                m.nom = obj.nom;
                m.mot_de_passe = obj.mot_de_passe;
                m.image_url = "";
                m.date_de_cretaation = DateTime.Now;
                m.statut = obj.statut;
                m.image_url = "man.png";
                m.sexe = "Masculin";




                db.Membre.Add(m);

                db.SaveChanges();

                ViewBag.EmailMessage3 = "Demande envoyée avec succès Vous recevrez un email si votre demande a été validé";
                return View();

            }
            else if (Request.Form["sexe"] == "Feminin")
            {
                Membre m = new Membre();

                m.email = obj.email;
                m.prenom = obj.prenom;
                m.nom = obj.nom;
                m.mot_de_passe = obj.mot_de_passe;
                m.image_url = "";
                m.date_de_cretaation = DateTime.Now;
                m.statut = obj.statut;
                m.image_url = "woman.png";
                m.sexe = "Feminin";




                db.Membre.Add(m);

                db.SaveChanges();
                ViewBag.EmailMessage3 = "Demande envoyée avec succès Vous recevrez un email si votre demande a été validé";

                return View();

            }



            ViewBag.EmailMessage4 = "Veuillez choisir Votre ";
            return View();


        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChatRoom(LoginVM obj)
        {
            var Membre = db.Membre.ToList();
            var membred = Membre.Find(a => a.email == obj.email);
           



            bool EmailExiste2 = db.Membre.Any(x => x.mot_de_passe == obj.mot_de_passe);
            bool EmailExiste3 = db.Membre.Any(y => y.email == obj.email);

            if (EmailExiste2 && EmailExiste3 && membred.statut!="Guest")
            {
                return View(membred);
               
            }
            ViewBag.EmailMessage2 = "Adresse Email  ou Mot de passe non valide";
            return RedirectToAction("Login", "CreateCompte");








        }

        // GET: InscriptionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InscriptionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InscriptionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InscriptionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
