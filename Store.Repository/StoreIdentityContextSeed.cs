using Microsoft.AspNetCore.Identity;
using Store.Data.Entites.identityAppUser;

namespace Store.Repository
{
    public class StoreIdentityContextSeed
    {

        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {

            try
            {


            if (!userManager.Users.Any())
            {
                var user = new AppUser()
                {
                    DisplayName = "Kerollos Emad",
                    Email = "EmadKero318@gmail.com",
                    UserName = "KerollosEmad",
                    Address =new Address
                    { 
                        FirstName = "Kerollos",
                        LastName = "Emad",
                        City = "Alf Maskan",
                        Street = "38",
                        State = "Cairo",
                        PostalCode = "123456"
                        
                    
                    }





                };

                 await userManager.CreateAsync(user, "Pasword12345!");
            
            }

            
        
        
            }
            catch (Exception ex)
            {

                
            }
        }


    }
}
