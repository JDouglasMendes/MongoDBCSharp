// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjetoPersistente.cs" company="DM">
//   DM
// </copyright>
// <summary>
//   The objeto persistente.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DM.MongoDBCSharp
{
    using System.Collections.Generic;

    using MongoDB.Bson;

    /// <summary>
    /// The objeto persistente.
    /// </summary>
    public class AgregadoPersistente
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AgregadoPersistente"/> class.
        /// </summary>
        public AgregadoPersistente()
        {
            this.Lista = new List<EntidadePersistente>();
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Gets or sets the lista.
        /// </summary>
        public IList<EntidadePersistente> Lista { get; set; }
    }
}
