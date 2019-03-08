using Newtonsoft.Json;
using ProtechTeste.Domain.Objects;
using ProtechTeste.Repository.Memory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProtechTeste.Repository.Context
{
    public class ProtechContext
    {

        private List<Funcionario> funcionarios;

        public List<Funcionario> Funcionarios
        {
            get
            {
                if (MemoryCacher.GetValue("ProtechContext") == null)
                    return new List<Funcionario>();
                return (List<Funcionario>)MemoryCacher.GetValue("ProtechContext");
            }

            set
            {
                funcionarios = value;

            }
        }

        public void LoadJson()
        {
            if ((MemoryCacher.GetValue("ProtechContext") == null))
            {
                using (StreamReader r = new StreamReader(HttpRuntime.AppDomainAppPath + "getResponse.json"))
                {
                    string json = r.ReadToEnd();
                    var func = JsonConvert.DeserializeObject<Funcionario>(json);
                    List<Funcionario> list = new List<Funcionario>();
                    list.Add(func);

                    MemoryCacher.Add("ProtechContext", list);
                }
            }

        }
    }
}
