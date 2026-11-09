# Feed NuGet Local

Esta pasta é usada como **Feed NuGet Local** do repositório.

O projeto `Comex.GeneradorRelatorio` está configurado com:

- `GeneratePackageOnBuild=true` — gera o `.nupkg` a cada build;
- `PackageOutputPath` apontando para esta pasta.

Após compilar o projeto, o arquivo `Comex.GeneradorRelatorio.1.0.0.nupkg` será colocado aqui
e poderá ser consumido por outros projetos através da fonte `comex-local` definida no
`nuget.config` da raiz do repositório.
