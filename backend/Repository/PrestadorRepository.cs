using Azure.Storage.Blobs;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Http;

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

    public void CreatePrestadorWithImagem(Prestador prestador, IFormFile imagem)
    {
        UploadImageToBlob(prestador, imagem);
        CreatePrestador(prestador);
    }

    public void UpdatePrestador(Prestador prestador)
    {
        Update(prestador);
    }

    public void UpdatePrestadorWithImagem(Prestador prestador, IFormFile imagem)
    {
        DeleteImageFromBlob(prestador);
        UploadImageToBlob(prestador, imagem);
        UpdatePrestador(prestador);
    }
    
    public void DeletePrestador(Prestador prestador)
    {
       // DeleteImageFromBlob(prestador);
        Delete(prestador);
    }

    private void UploadImageToBlob(Prestador prestador, IFormFile image)
    {
        if (image is null)
            return;
        
        var containerClient = _blobServiceClient.GetBlobContainerClient(ContainerName);

        var fileName = GetFileName(image);
        var imageUrl = $"{containerClient.Uri}/{fileName}";
            
        var blobClient = containerClient.GetBlobClient(fileName);
        using var imageData = image.OpenReadStream();
        blobClient.Upload(imageData);

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

    private static string GetFileName(IFormFile image)
    {
        return $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
    }
    
}
