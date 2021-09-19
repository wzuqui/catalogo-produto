dotnet tool restore
yarn install
dotnet user-secrets set ConnectionString "Server=.;Initial Catalog=CatalogoProduto;Persist Security Info=False;User ID=sa;Password=yourStrong(!)Password;" --project .\src\CatalogoProduto.Api\