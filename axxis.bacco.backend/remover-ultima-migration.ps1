Write-Output "Removendo a ultima migration criada"
dotnet ef migrations remove --context BaccoContext --project axxis.bacco.backend.infra.data
Write-Output "Migrations removidas com sucesso"
