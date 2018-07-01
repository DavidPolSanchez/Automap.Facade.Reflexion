using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace AutoMapperEjemplo
{
    class ClientRepository
    {
        public static void Main(string[] args)
        {
            /*var configmap = new MapperConfiguration(x =>
            {
                x.CreateMap<Client,ClientView>();
            });*/

            //utilizando lamda expressions
            var configmap = new MapperConfiguration (x => x.CreateMap<Client, ClientView>()
            .ForMember(dest => dest.Age,sou => sou.ResolveUsing( entity => DateTime.Today.AddTicks(-entity.Birthdate.Ticks).Year-1))
            .ForMember(dest => dest.Birthdate, opt=> opt.Ignore())
            );

           IMapper iMapper = configmap.CreateMapper();

            var clients = new Client();           
                clients.ClientId = 1;
            clients.Name = "David";
            clients.LastName = "Sanchez";
            clients.Email = "david_7_pol@hotmail.com";
            clients.Birthdate =new  DateTime(1998,4,28);
            clients.Password = "123456";

            // hacer el mapeo del objeto clients  desde client hasta clientview

            var clientviewmap = iMapper.Map<Client,ClientView>(clients);

            Console.WriteLine(clientviewmap.GetType());
            Console.WriteLine("Author Name: " + clientviewmap.Name + " " + clientviewmap.LastName +" // " + clientviewmap.Email + " // " +clientviewmap.Age );
            Console.ReadLine();
        }
            
    }
}
