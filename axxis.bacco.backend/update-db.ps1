param([string] $nome)

Write-Output "Atualizando banco dados via migration"
dotnet ef database update $nome --context BaccoContext --project axxis.bacco.backend.infra.data
Write-Output "Banco atualizado com sucesso"
