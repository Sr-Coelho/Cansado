using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Firebase.Database.Query;
using Firebase.Database;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Cansado.Tables;

namespace Cansado.Helpers
{
    public class ApiServices
    {
        private JsonSerializer _serializer = new JsonSerializer();

        private static ApiServices _ServiceClientInstance;



        public static ApiServices ServiceClientInstance
        {
            get
            {
                if (_ServiceClientInstance == null)
                    _ServiceClientInstance = new ApiServices();
                return _ServiceClientInstance;
            }
        }

        FirebaseClient firebase;
        public ApiServices()
        {
            //replace this with your firebase realtimedatabase end point.
            firebase = new FirebaseClient("https://cansado-3dcfc.firebaseio.com/Idoso");
        }


        #region ClientSection


        //[Pushing Single table to the Database]
        public async Task<bool> RegistrarUsuario(string NomeCompleto, string CPF, string Senha, int Idade)
        {
            var result = await firebase
                .Child("RegistroDosIdosos")
                .PostAsync(new TableDeRegistro() { IdUsuario = Guid.NewGuid(), NomeCompleto = NomeCompleto, CPF = CPF, Senha = Senha, Idade = Idade });

            if (result.Object != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Login with clients credentials. 
        public async Task<TableDeRegistro> LogarUsuario(string CPF, string Senha)
        {
            var GetPerson = (await firebase
              .Child("RegistroDosIdosos")
              .OnceAsync<TableDeRegistro>()).Where(a => a.Object.CPF == CPF).Where(b => b.Object.Senha == Senha).FirstOrDefault();

            if (GetPerson != null)
            {
                var content = GetPerson.Object as TableDeRegistro;
                return content;
            }
            else
            {
                return null;
            }
        }

        //Get all the task of the clients
        /*public async Task<List<TasksModel>> GetClientTasks(string userId)
        {
            var GetTasks = (await firebase
              .Child("EmployeeTaskTable")
              .OnceAsync<TasksModel>()).Where(a => a.Object.ClientID.ToString() == userId).Select(item => new TasksModel
              {
                  ClientID = item.Object.ClientID,
                  TaskTitle = item.Object.TaskTitle,
                  TaskId = item.Object.TaskId,
                  clientTasks = item.Object.clientTasks
              }).ToList(); ;

            if (GetTasks != null)
            {
                return new List<TasksModel>(GetTasks);
            }
            else
            {
                return null;
            }
        }*/

        //[Pushing Single table to the Database]
        public async Task<bool> RegistrarAula(string NomeDaAulaYou, string URLdaAulaYou)
        {
            var result = await firebase
                .Child("Aulas")
                .PostAsync(new TableDeAula() { IdAula = Guid.NewGuid(), NomeDaAulaYou = NomeDaAulaYou, URLdaAulaYou = URLdaAulaYou});

            if (result.Object != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Get All the registered Client Users

        public async Task<List<TableDeAula>> PegarAulas()
        {
            var PegarAsAulas = (await firebase
               .Child("Aulas")
               .OnceAsync<TableDeAula>()).Select(item => new TableDeAula
               {
                   NomeDaAulaYou = item.Object.NomeDaAulaYou,
                   URLdaAulaYou = item.Object.URLdaAulaYou,
                   IdAula = item.Object.IdAula
               }).ToList();
            return PegarAsAulas;
        }
        #endregion

        #region AdminSection

        //Get All the registered Client Users

        public async Task<List<TableDeRegistro>> PegarIdososRegistrados()
        {
            var GetClients = (await firebase
               .Child("RegistroDosIdosos")
               .OnceAsync<TableDeRegistro>()).Select(item => new TableDeRegistro
               {
                   NomeCompleto = item.Object.NomeCompleto,
                   CPF = item.Object.CPF,
                   Idade = item.Object.Idade,
                   IdUsuario = item.Object.IdUsuario
               }).ToList();
            return GetClients;
        }


        // [Pushing Nested table to the Database]
        /*public async Task AssignTaskToClient(TasksModel tasks)
        {
            var result = await firebase
            .Child("EmployeeTaskTable")
            .PostAsync(new TasksModel()
            {
                ClientID = tasks.ClientID,
                TaskId = tasks.TaskId,
                TaskTitle = tasks.TaskTitle,
                clientTasks = tasks.clientTasks
            });
        }*/


        //Update the database
        /*public async Task<bool> DeleteDatabaseConetent(TasksModel tasksModel)
        {
            var DeleteUserDb = (await firebase
             .Child("EmployeeTaskTable")
             .OnceAsync<TasksModel>()).Where(a => a.Object.TaskId == tasksModel.TaskId).FirstOrDefault();
            await firebase.Child("EmployeeTaskTable").Child(DeleteUserDb.Key).DeleteAsync();


            if (DeleteUserDb.Object != null)
            {
                return true;
            }
            else
            {
                return false;

            }
        }*/



        //Register Admin User
        public async Task<bool> RegistrarUsuarioAdmin(string CPF, string Senha)
        {
            var result = await firebase
           .Child("RegistroDosAdmin")
           .PostAsync(new TableDeRegistro() { IdUsuario = Guid.NewGuid(), CPF = CPF, Senha = Senha });

            if (result.Object != null)
            {
                return true;
            }
            else
            {
                return false;

            }
        }


        //Login AdminUser
        public async Task<TableDeRegistro> LogarUsuarioAdmin(string CPF, string Senha)
        {
            var GetPerson = (await firebase
              .Child("RegistroDosAdmin")
              .OnceAsync<TableDeRegistro>()).Where(a => a.Object.CPF == CPF).Where(b => b.Object.Senha == Senha).FirstOrDefault();

            if (GetPerson != null)
            {

                var content = GetPerson.Object as TableDeRegistro;
                return content;

            }
            else
            {
                return null;
            }
        }

        #endregion

    }
}
