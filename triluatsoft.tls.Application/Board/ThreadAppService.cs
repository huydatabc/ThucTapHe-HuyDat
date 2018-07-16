using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using triluatsoft.tls.Board.ThreadDTO;
using Abp.UI;

namespace triluatsoft.tls.Board
{
    public class ThreadAppService : ApplicationService, IThreadAppService
    {
        private readonly IRepository<Thread> _threadRepository;

        public ThreadAppService(IRepository<Thread> threadRepository)
        {
            _threadRepository = threadRepository;
        }

        public async Task Create(CreateThreadInput input)
        {
            Thread output = input.MapTo<Thread>();


            await _threadRepository.InsertAsync(output);
        }

        public void Delete(DeleteThreadInput input)
        {
            var thread = _threadRepository.FirstOrDefault(x => x.Id == input.Id);
            if (thread == null)
            {
                throw new UserFriendlyException("No Data Found");
            }
            else
            {
                _threadRepository.Delete(thread);
            }
        }

        public GetThreadOutput GetThreadById(GetThreadInput input)
        {
            var thread = _threadRepository.FirstOrDefault(x => x.Id == input.Id);
            if (thread == null)
            {
                throw new UserFriendlyException("No Data Found");
            }
            else
            {
                var getThread = _threadRepository.Get(input.Id);
                var temp = new GetThreadOutput
                {
                    Id = getThread.Id,
                    Content = getThread.Content,
                    CreatorId = getThread.CreatorId,
                    MediaPath = getThread.MediaPath,
                    FileExtension = getThread.FileExtension,
                    PosterName = getThread.PosterName
                }
                .MapTo<GetThreadOutput>();
                //GetPosterOutput output = Mapper.Map<Poster, GetPosterOutput>(getPoster);
                //GetPosterOutput output1 = getPoster.MapTo<Poster>();
                //GetPosterOutput output1 = Mapper.Map<Poster, GetPosterOutput>(getPoster);
                //GetPosterOutput output1 = getPoster.MapTo<GetPosterOutput>();

                return temp;
            }
        }

        public Array ListAll()
        {
            var getAll = _threadRepository.GetAll()
                           .Select(p => new
                           {
                               Count = p.Id,
                               Text = p.Content,
                               MediaPath = p.MediaPath,
                               Poster = p.CreatorId,
                               PosterName = p.PosterName,
                               FileExtension = p.FileExtension
                           }).ToArray();
            /*var getAll = _posterRepository.GetAll().Select(n => new
            {
                Name = n.PosterName, //get by foreign key
                n.PosterName.nae
            });
            */
            return getAll;
        }

        public void Update(UpdateThreadInput input)
        {
            Thread output = input.MapTo<Thread>();
            _threadRepository.Update(output);
        }
    }
}
