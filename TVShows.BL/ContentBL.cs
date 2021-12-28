using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVShows.DAL;
using TVShows.Domain;

namespace TVShows.BL;

public class ContentBL : IContentBL
{
    private readonly IContentRepository _contentRepository;

    public ContentBL(IContentRepository contentRepository)
    {
        _contentRepository = contentRepository;
    }

    public IList<Contents> CreateContent(Contents contents)
    {
        return _contentRepository.CreateContent(contents);
    }

    public IList<Contents> GetAll()
    {
        return _contentRepository.GetAll();
    }


}

