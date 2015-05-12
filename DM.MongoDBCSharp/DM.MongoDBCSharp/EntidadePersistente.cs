// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntidadePersistente.cs" company="DM">
//   DM
// </copyright>
// <summary>
//   The entidade persistente.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DM.MongoDBCSharp
{
    using System.Collections.Generic;

    using MongoDB.Bson;

    /// <summary>
    /// The entidade persistente.
    /// </summary>
    public class EntidadePersistente
    {        
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// Gets or sets the descricao.
        /// </summary>
        public string Descricao { get; set; }
    }
}
