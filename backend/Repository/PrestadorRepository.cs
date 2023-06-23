using Azure.Storage.Blobs;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository;
public class PrestadorRepository : RepositoryBase<Prestador>, IPrestadorRepository
{
    private const string ContainerName = "prestadorimg";
    private readonly BlobServiceClient _blobServiceClient;

    public PrestadorRepository(RepositoryContext repositoryContext, BlobServiceClient blobServiceClient) 
        : base(repositoryContext)
    {
        _blobServiceClient = blobServiceClient;
    }

     public IEnumerable<Prestador> GetAllPrestadores()
    {
         return FindAll()
            .OrderBy(prest => prest.NomeFantasia)
            .ToList();
    }

    public Prestador GetPrestadorById(int prestadorId)
    {
        return FindByCondition(prest => prest.Id.Equals(prestadorId))
            .FirstOrDefault();
    }

    public Prestador GetPrestadorDetailed(int prestaId)
    {
        return FindByCondition(presta => presta.Id.Equals(prestaId))
            .FirstOrDefault();
    }

    public void CreatePrestador(Prestador prestador)
    {
        
        Create(prestador);
    }

    public void CreatePrestadorWithImagem(Prestador prestador, Stream imagem)
    {
        UploadImageToBlob(prestador, imagem, false);
        CreatePrestador(prestador);
    }

    public void UpdatePrestador(Prestador prestador)
    {
        Update(prestador);
    }

    public void UpdatePrestadorWithImagem(Prestador prestador, Stream imagem)
    {
        UploadImageToBlob(prestador, imagem, true);
        UpdatePrestador(prestador);
    }
    
    public void DeletePrestador(Prestador prestador)
    {
        DeleteImageFromBlob(prestador);
        Delete(prestador);
    }

    private void UploadImageToBlob(Prestador prestador, Stream image, bool @override)
    {
        if (image is null)
            return;
        
        var containerClient = _blobServiceClient.GetBlobContainerClient(ContainerName);

        string fileName, imageUrl;
        if (@override)
        {
            fileName = prestador.Imagem;
            imageUrl = fileName;
        }
        else
        {
            fileName = GetFileNameForPrestador(prestador);
            imageUrl = $"{containerClient.Uri}/{fileName}";   
        }
        
        var blobClient = containerClient.GetBlobClient(fileName);
        blobClient.Upload(image, @override);

        prestador.Imagem = imageUrl;
    }

    private void DeleteImageFromBlob(Prestador prestador)
    {
        if (string.IsNullOrEmpty(prestador.Imagem))
            return;
        
        var containerClient = _blobServiceClient.GetBlobContainerClient(ContainerName);
        var blobClient = containerClient.GetBlobClient(prestador.Imagem);
        blobClient.Delete();
    }

    private static string GetFileNameForPrestador(Prestador prestador)
    {
        return $"{Guid.NewGuid()}{Path.GetExtension(prestador.Imagem)}";
    }
    
}
