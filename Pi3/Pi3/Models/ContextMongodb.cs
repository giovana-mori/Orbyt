﻿using MongoDB.Driver;

namespace Pi3.Models
{
    public class ContextMongodb
    {
        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public static bool IsSSL { get; set; }
        private IMongoDatabase _database { get; }

        public ContextMongodb()
        {
            try
            {
                MongoClientSettings setting = MongoClientSettings.
                    FromUrl(new MongoUrl(ConnectionString));

                if (IsSSL)
                {
                    setting.SslSettings = new SslSettings
                    {
                        EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
                    };
                }

                var mongoCliente = new MongoClient(setting);
                _database = mongoCliente.GetDatabase(DatabaseName);

            }
            catch (Exception)
            {
                throw new Exception("Não foi possivel conectar");
            }
        }

        public IMongoCollection<Usuario> Usuario
        {
            get
            {
                return _database.GetCollection<Usuario>("Usuario");
            }
        }
        public IMongoCollection<Avaliacao> Avaliacao
        {
            get
            {
                return _database.GetCollection<Avaliacao>("Avaliacao");
            }
        }
    }
}
