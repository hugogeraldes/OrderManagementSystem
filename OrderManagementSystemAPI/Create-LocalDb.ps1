# Check if the LocalDB instance already exists
$instanceName = "OrderManagementDB"
$existingInstances = sqllocaldb info

if ($existingInstances -contains $instanceName) {
    Write-Host "LocalDB instance '$instanceName' already exists." -ForegroundColor Green
    
    # Start the instance if it's not running
    sqllocaldb start $instanceName
    Write-Host "Started LocalDB instance '$instanceName'." -ForegroundColor Green
}
else {
    Write-Host "Creating new LocalDB instance '$instanceName'..." -ForegroundColor Yellow
    
    # Create and start the instance
    sqllocaldb create $instanceName -s
    Write-Host "LocalDB instance '$instanceName' created and started." -ForegroundColor Green
}

# Display instance information
Write-Host "`nInstance Information:" -ForegroundColor Cyan
sqllocaldb info $instanceName