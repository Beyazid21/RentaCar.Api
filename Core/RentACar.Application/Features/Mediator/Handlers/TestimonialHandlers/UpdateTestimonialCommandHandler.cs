using MediatR;
using RentaCar.Domain.Entities;
using RentACar.Application.Features.Mediator.Commands.TestimonialCommands;
using RentACar.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Testimonials.Mediator.Handlers.TestimonialHandlers
{
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(x=>x.TestimonialId==request.TestimonialId);

           value.Title = request.Title;
            value.Comment = request.Comment;
            value.Name = request.Name;
            value.ImageUrl = request.ImageUrl;

            await _repository.UpdateAsync(value);
        }
    }
}
