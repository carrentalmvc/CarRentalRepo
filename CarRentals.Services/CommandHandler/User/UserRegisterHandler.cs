using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentals.Services.Commands;
using CarRentals.Services.Command;
using CarRentals.Repository;
using CarRentals.Model.DomainObjects;

namespace CarRentals.Services.CommandHandler.User
{
   public  class UserRegisterHandler : ICommandHandler<UserRegisterCommand>
    {
       private readonly ICarRentalUserRepository userRepo;
       private readonly IUnitOfWork uow;

       public UserRegisterHandler(ICarRentalUserRepository userRepository, IUnitOfWork unitOfWork)
       {
           this.userRepo = userRepository;
           this.uow = unitOfWork;
       }

        public ICommandResult Execute(UserRegisterCommand command)
        {
            bool result = true;
            try
            {
                var carRentalUser = new CarRentalUser
                {

                    FirstName = command.FirstName,
                    LastName = command.LastName,
                    EmailAddress = command.Email,
                    Password = command.Password
                    
                };

                userRepo.Add(carRentalUser);
                uow.Commit();
                
            }
            catch (Exception ex)
            {
                //log the error
                //To DO: figure out a way to do Rollback in Uow
                result = false;
            }

            return new CommandResult(result);
            
        }
    }
}
