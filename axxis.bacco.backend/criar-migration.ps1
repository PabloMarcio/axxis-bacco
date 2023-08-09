param([string] $nome)

Write-Output "Iniciando a cria��o de uma nova migration"
if ($nome -eq "") {    
	Write-Output "Nome da migration n�o foi informado"
    exit
}

Write-Output "Nome da migration $($nome)"

Write-Output "Criando banco de dados..."
dotnet ef migrations add $nome --context BaccoContext --project axxis.bacco.backend.infra.data --output-dir Migrations/
Write-Output "Migrations criadas com sucesso"