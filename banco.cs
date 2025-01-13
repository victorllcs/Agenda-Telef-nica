using System;
using System.Security;

//A classe ConexaoBanco é estática para que o método de conexão possa ser utilizado sem a necessiade de instanciar uma nova classe
public static class ConexaoBanco
{
    //As variáveis abaixo devem ser preenchidas com informações de login do banco de dados
    private const string servidor = "***";
    private const string bancoDados = "***";
    private const string usuario = "***";
    private const string senha = "***";

    //String para realizar a conexão com o banco de dados.
    public static string conexaoBanco = $"server={servidor};user id={usuario};database={bancoDados};password={senha}";
}

