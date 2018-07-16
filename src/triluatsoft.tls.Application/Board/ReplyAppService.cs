using Abp.Application.Services;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using triluatsoft.tls.Board.ReplyDTO;

namespace triluatsoft.tls.Board
{
    public class ReplyAppService : ApplicationService, IReplyAppService
    {
        private readonly IRepository<Reply> _replyRepository;
        private readonly IRepository<Poster> _posterRepository;

        public ReplyAppService(IRepository<Reply> replyRepository)
        {
            _replyRepository = replyRepository;
        }

        public async Task Create(CreateReplyInput input)
        {
            Reply output = input.MapTo<Reply>();
            //Poster check = input.MapTo<Poster>();
            //Thread threadcheck = input.MapTo<Thread>();


            await _replyRepository.InsertAsync(output);

        }


        public void Delete(DeleteReplyInput input)
        {
            var reply = _replyRepository.FirstOrDefault(x => x.Id == input.Id);
            if (reply == null)
            {
                throw new UserFriendlyException("No Data Found");
            }
            else
            {
                _replyRepository.Delete(reply);
            }
        }

        public GetReplyOutput GetReplyById(GetReplyInput input)
        {
            var reply = _replyRepository.FirstOrDefault(x => x.Id == input.Id);
            if (reply == null)
            {
                throw new UserFriendlyException("No Data Found");
            }
            else
            {
                var getReply = _replyRepository.Get(input.Id);
                var temp = new GetReplyOutput
                {
                    Id = getReply.Id,
                    Content = getReply.Content,
                    CreatorId = getReply.CreatorId,
                    ThreadId = getReply.ThreadId,
                    MediaPath = getReply.MediaPath,
                    FileExtension = getReply.FileExtension,
                    PosterName = getReply.PosterName
                }
                .MapTo<GetReplyOutput>();
                //GetPosterOutput output = Mapper.Map<Poster, GetPosterOutput>(getPoster);
                //GetPosterOutput output1 = getPoster.MapTo<Poster>();
                //GetPosterOutput output1 = Mapper.Map<Poster, GetPosterOutput>(getPoster);
                //GetPosterOutput output1 = getPoster.MapTo<GetPosterOutput>();

                return temp;
            }
        }

        public Array ListAll()
        {
            var getAll = _replyRepository.GetAll()
                .Select(p => new
                {
                    Count = p.Id,
                    Text = p.Content,
                    Poster = p.CreatorId,
                    p.ThreadId,
                    MediaPath = p.MediaPath,
                    FileExtention = p.FileExtension,
                    PosterName = p.PosterName
                }).ToArray();
            /*var getAll = _posterRepository.GetAll().Select(n => new
            {
                Name = n.PosterName, //get by foreign key
                n.PosterName.nae
            });
            */
            return getAll;
        }

        public void Update(UpdateReplyInput input)
        {
            Reply output = input.MapTo<Reply>();
            _replyRepository.Update(output);
        }

        public Array GetReplyByThreadId(GetReplyByThreadIdInput input) //
        {
            var getAll = _replyRepository.GetAll()
          .Select(p => new
          {
              Count = p.Id,
              Text = p.Content,
              Poster = p.CreatorId,
              p.ThreadId,
              MediaPath = p.MediaPath,
              FileExtension = p.FileExtension,
              PosterName = p.PosterName
          }).Where(x => x.ThreadId == input.ThreadId).ToArray();
            return getAll;               //.Where(x => x.ThreadId == input.ThreadId).
        }
    }
}
