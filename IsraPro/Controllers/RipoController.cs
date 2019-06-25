using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using IsraPro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IsraPro.Controllers
{

    public class Root
    {
        public Ripository[] Items;
    }

  
    public class Owner
    {
        public string avatar_url;
    }

    public class RipoController : Controller
    {
        public const string SessionKeyName = "_Name";

        public static Ripository SessionRiposiroty;
        ComplexClass objComplex = new ComplexClass();
        public static List<Ripository> Ripositories = new List<Ripository>();

        public static int Id { get; set; }
        public string Name { get; set; }

        public static  List<Root> a = new List<Root>();

       
        public IActionResult Index()
        {

            if (SessionRiposiroty != null)
            {

            ViewBag.Ripositories = Ripositories;
            }

            return View();
        }

       

        public List<Ripository> Session(int id)
         {
            var bb = from item in a[0].Items
                     where item.Id == id
                     select item;
            //var b = a[0].Items[0];

            foreach (var itema in bb)
            {
                SessionRiposiroty = itema;
                HttpContext.Session.SetObject("ComplexObject", SessionRiposiroty);
                var objComplex = HttpContext.Session.GetObject<Ripository>("ComplexObject");
                Ripositories.Add(objComplex);
                // SessionRiposiroty = new Ripository() { Name = itema.Name };
            }

            return Ripositories;




        }

        public async Task<List<Root>> Search(string name)
        {
            List<Root> tempRipo = new List<Root>();
            a.Clear();
            string url = "https://api.github.com/search/repositories?q=" + name;


            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "C# App");
            var message = await client.GetAsync(url);

            var result = message.Content.ReadAsStringAsync().Result;

            Root obj = JsonConvert.DeserializeObject<Root>(result);

            tempRipo.Add(obj);


            a.Add(obj);


            return a;


        }
    }
}