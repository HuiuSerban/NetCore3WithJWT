using JWT;
using JWT.Builder;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreJWT.ActionFIlters
{
    public class CustomActionFilter : ActionFilterAttribute
    {
        private string secret = "THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING";
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var jwt = context.HttpContext.Request.Headers["JWT"];

            try
            {
                var json = new JwtBuilder()
                    .WithSecret(secret)
                    .MustVerifySignature()
                    .Decode(jwt);

                var tokenDetails = JsonConvert.DeserializeObject<dynamic>(json);
            }
            catch (TokenExpiredException)
            {
                throw new Exception("Token is expired");
            }
            catch (SignatureVerificationException)
            {
                throw new Exception("Token signature invalid");
            }
            catch (Exception ex)
            {
                throw new Exception("Token has been tempered with");
            }
        }
    }
}
