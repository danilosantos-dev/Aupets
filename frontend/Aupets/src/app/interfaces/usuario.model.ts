export interface Usuario {
    id: string;
    nome: string;
    senha: string;
    senhaHash: string;
    email: string;
    imagem: string;
    eAdmin: boolean;
}