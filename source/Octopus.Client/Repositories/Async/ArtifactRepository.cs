using System;
using System.IO;
using System.Threading.Tasks;
using Octopus.Client.Extensibility;
using Octopus.Client.Model;

namespace Octopus.Client.Repositories.Async
{
    public interface IArtifactRepository :
        IPaginate<ArtifactResource>,
        IGet<ArtifactResource>,
        ICreate<ArtifactResource>,
        IModify<ArtifactResource>,
        IDelete<ArtifactResource>
    {
        Task<Stream> GetContent(ArtifactResource artifact);
        Task PutContent(ArtifactResource artifact, Stream contentStream);
        Task<ResourceCollection<ArtifactResource>> FindRegarding(IResource resource);
    }

    class ArtifactRepository : BasicRepository<ArtifactResource>, IArtifactRepository
    {
        public ArtifactRepository(IOctopusAsyncClient client)
            : base(client, "Artifacts")
        {
        }

        public Task<Stream> GetContent(ArtifactResource artifact)
        {
            return Client.GetContent(artifact.Link("Content"));
        }

        public Task PutContent(ArtifactResource artifact, Stream contentStream)
        {
            return Client.PutContent(artifact.Link("Content"), contentStream);
        }

        public Task<ResourceCollection<ArtifactResource>> FindRegarding(IResource resource)
        {
            return Client.List<ArtifactResource>(Client.Link("Artifacts"), new { regarding = resource.Id });
        }
    }
}
