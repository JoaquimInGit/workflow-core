﻿using System;
using Microsoft.Azure.Cosmos;
using WorkflowCore.Providers.Azure.Interface;

namespace WorkflowCore.Providers.Azure.Services
{
    public class CosmosDbClient : ICosmosDbClient, IDisposable
    {
        private bool isDisposed = false;

        public CosmosClient _client;

        public CosmosDbClient(string connectionString)
        {
            _client = new CosmosClient(connectionString);
        }

        public CosmosClient GetCosmosClient()
        {
            return this._client;
        }

        /// <summary>
        /// Dispose of cosmos client
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Dispose of cosmos client
        /// </summary>
        /// <param name="disposing">True if disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                if (disposing)
                {
                    this._client.Dispose();
                }

                this.isDisposed = true;
            }
        }
    }
}