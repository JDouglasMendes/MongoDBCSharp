// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="DM">
//   Todos os direitos reservados (Ah fala serio pode usar na boa!!)
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DM.MongoDBCSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MongoDB.Bson;
    using MongoDB.Driver;

    /// <summary>
    /// Inicia o programa
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Método para manipular os dados utilizando documentos tipados.        
        /// </summary>
        public static async void UsandoDocumentosSemTipo()
        {
            try
            {
                var driverCliente = new MongoClient("mongodb://localhost");
                var bancoDeDados = driverCliente.GetDatabase("blogsharp");
                var colecao = bancoDeDados.GetCollection<BsonDocument>("tabela");
                await colecao.InsertOneAsync(new BsonDocument("Name", "Douglas Mendes"));
                var listaDeRetorno = await colecao.Find(new BsonDocument("Name", "Douglas Mendes")).ToListAsync();

                foreach (var documento in listaDeRetorno)
                {
                    Console.WriteLine(documento["Name"]);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /// <summary>
        /// Método para manipular dados usando documento tipado.
        /// </summary>
        public static async void UsandoDocumentoTipado()
        {
            try
            {
                var driverCliente = new MongoClient("mongodb://localhost");
                var bancoDeDados = driverCliente.GetDatabase("blogsharp");
                var colecao = bancoDeDados.GetCollection<AgregadoPersistente>("agregadoTipado");
                var agregado = new AgregadoPersistente // Objeto que vamos inserir na coleção!!
                                   {
                                       Descricao = "Descrição do agregado",
                                       Lista = new List<EntidadePersistente>()
                                                   {
                                                       new EntidadePersistente()
                                                           {
                                                               Descricao = "Descrição da entidade"
                                                           }
                                                   }
                                   };

                await colecao.InsertOneAsync(agregado);
                var listaDeRetorno = await colecao.Find(x => x.Descricao == "Descrição do agregado").ToListAsync();
                foreach (var agregadoItem in listaDeRetorno)
                {
                    Console.WriteLine(agregadoItem.Descricao);
                    if (agregadoItem.Lista != null)
                    {
                        agregadoItem.Lista.ToList().ForEach(x => Console.WriteLine(x.Descricao));
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Main(string[] args)
        {
           UsandoDocumentoTipado();
           UsandoDocumentosSemTipo();
        }
    }
}
