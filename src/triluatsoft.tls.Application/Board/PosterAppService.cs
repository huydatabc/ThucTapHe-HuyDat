using Abp.Application.Services;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using triluatsoft.tls.Board.PosterDTO;

namespace triluatsoft.tls.Board
{
    public class PosterAppService : ApplicationService, IPosterAppService
    {
        private readonly IRepository<Poster> _posterRepository;

        public PosterAppService(IRepository<Poster> posterRepository)
        {
            _posterRepository = posterRepository;
        }

        public async Task Create(CreatePosterInput input)
        {
            Poster output = input.MapTo<Poster>();
            //await _authorManager.Create(output);
            var poster = _posterRepository.FirstOrDefault(x => x.Id == output.Id);
            if (poster != null)
            {
                throw new UserFriendlyException("Already Exist");
            }
            else
            {
                await _posterRepository.InsertAsync(output);
            }
        }


        public void Delete(DeletePosterInput input)
        {
            var poster = _posterRepository.FirstOrDefault(x => x.Id == input.Id);
            if (poster == null)
            {
                throw new UserFriendlyException("No Data Found");
            }
            else
            {
                _posterRepository.Delete(poster);
            }
        }

        public GetPosterOutput GetPosterById(GetPosterInput input)
        {

            var poster = _posterRepository.FirstOrDefault(x => x.Id == input.Id);
            if (poster == null)
            {
                throw new UserFriendlyException("No Data Found");
            }
            else
            {
                var getPoster = _posterRepository.Get(input.Id);
                var temp = new GetPosterOutput
                {
                    Id = getPoster.Id,
                    PosterName = getPoster.PosterName,
                    PosterId = getPoster.PosterId
                }
                .MapTo<GetPosterOutput>();
                //GetPosterOutput output = Mapper.Map<Poster, GetPosterOutput>(getPoster);
                //GetPosterOutput output1 = getPoster.MapTo<Poster>();
                //GetPosterOutput output1 = Mapper.Map<Poster, GetPosterOutput>(getPoster);
                //GetPosterOutput output1 = getPoster.MapTo<GetPosterOutput>();

                return temp;
            }
        }

        public void Update(UpdatePosterInput input)
        {
            Poster output = input.MapTo<Poster>();
            _posterRepository.Update(output);
        }
        public Array ListAll()
        {
            var getAll = _posterRepository.GetAll()
                .Select(p => new
                {
                    Count = p.Id,
                    Name = p.PosterName,
                    stt = p.PosterId,
                }).ToArray();
            /*var getAll = _posterRepository.GetAll().Select(n => new
            {
                Name = n.PosterName, //get by foreign key
                n.PosterName.nae
            });
            */
            return getAll;
        }
    }
}

