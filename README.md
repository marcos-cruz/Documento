# Documento

Biblioteca de documentos emitidos no território Brasileiro.

# Objetivo

Disponibilizar uma biblioteca que facilite a criação e utilização de documentos como por exemplo, CPF e CNPJ, em projetos dotnet C#.

# Documentos suportados

| Classe | Documento | Descrição |
|-|-|-|
| ``` Cei ``` | Cei | Cadastro Específico do INSS |
| ``` Cnpj ``` | Cnpj | Cadastro Nacional de Pessoas Jurídicas |
| ``` Cpf ``` | Cpf | Cadastro de Pessoas Fisícas |
| ``` InscricaoEstadual ``` | Inscrição Estadual | Cadastro de Contribuintes do ICMS |
| ``` Pis ``` | Pis | Programa de Integração Social  |
| ``` TituloEleitor ``` | Título de Eleitor | Cadastro do Eleitor |

# Instalação

TODO: Disponibilizar Nuget Package

# Utilização

A mesma lógica demonstrada a seguir pode ser utilizada com ``` Cei ```, ``` Cnpj ```, ``` Cpf ```, ``` Cpf ```, ``` Pis ``` e ``` TituloEleitor ```, bastando para isto chamar o método ``` Factory ``` com os parâmetros que correspondem ao documento desejado.

```csharp

//
// Retorna um Cnpj.
//
var cnpj = Cnpj.Factory("02.270.949/0001-37");

//
// ou
//
IDocumento outroCnpj = Cnpj.Factory("02.270.949/0001-37");

//
// Retorna uma Inscrição Estadual
//
var ie = InscricaoEstadual.Factory("110.042.490.114", "SP");

//
// ou
//
IDocumento outraIe = InscricaoEstadual.Factory("P-01100424.3/002", "SP");

//
// Lista de documentos
//
var documentos = new List<IDocumento>();
documentos.Add(cnpj);
documentos.Add(outroCnpj);
documentos.Add(ie);

```
