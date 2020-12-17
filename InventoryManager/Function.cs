using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using InventoryManagerDatabase;
using InvertoryManager.blo.services;
using System.Text.Json.Serialization;
using inventoryManager.client;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace InventoryManager
{
    public class Functions
    {
        
        /// <summary>
        /// A Lambda function to respond to HTTP Get methods from API Gateway
        /// </summary>
        /// <param name="request"></param>
        /// <returns>The API Gateway response.</returns>
        public APIGatewayProxyResponse GetPallet(APIGatewayProxyRequest request)
        {
            if(request.PathParameters != null && request.PathParameters.ContainsKey("palletid")
                && int.TryParse(request.PathParameters["palletid"],out var palletid))
            {
                InventoryManagerContext con = new InventoryManagerContext();
                palletservice palletser = new palletservice(con);
                GetPalletResponse res = palletser.getpalletResponse(palletid);
                return new APIGatewayProxyResponse
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Body = JsonConvert.SerializeObject(res)
                };
            }
           // InventoryManagerContext inventoryManager = 

            

            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.NotFound
              
            };

            return response;
        }
    }
}
