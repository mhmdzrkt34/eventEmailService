using ApiService.Requests.Auth;
using ApiService.Responces.Auth.Register;
using Events;

using MassTransit;
using MassTransit.Transports;

namespace ApiService.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IBus _bus;


        public AuthService(IBus bus)
        {

            _bus = bus;
        }
        public async Task<RegisterResponceBase> Register(RegisterRequest request)
        {
            try
            {

                Uri uri = new Uri("rabbitmq://localhost/email_consumer_queue");
                SendEmailEvent eventt = new SendEmailEvent()
                {
                    email = request.email

                };
                ISendEndpoint sendEndpoint = await _bus.GetSendEndpoint(uri);

                await sendEndpoint.Send(eventt);


                return new RegisterResponceSuccess()
                {
                    status = 200,

                    body = new RegisterResponceSuccesBody()
                    {

                        message = "email sended succesfully"
                    },
                    type = "success"

                };



               
                
            }
            catch(Exception ex)
            {

                throw;
            }
        }
    }
}
