
# Set Working Directory
Split-Path $MyInvocation.MyCommand.Path | Push-Location
[Environment]::CurrentDirectory = $PWD

./Publish.ps1 -ProjectPath "Riders.Controller.Hook/Riders.Controller.Hook.Custom/Riders.Controller.Hook.Custom.csproj" `
              -PackageName "Riders.Controller.Hook.Custom" `
              -PublishOutputDir "Publish/ToUpload/Custom" `
              -MetadataFileName "Riders.Controller.Hook.Custom.ReleaseMetadata.json" `
			  -RemoveExe $False `
			  -ReadmePath README-CUSTOM.md

./Publish.ps1 -ProjectPath "Riders.Controller.Hook/Riders.Controller.Hook.PostProcess/Riders.Controller.Hook.PostProcess.csproj" `
              -PackageName "Riders.Controller.Hook.PostProcess" `
              -PublishOutputDir "Publish/ToUpload/PostProcess" `
              -MetadataFileName "Riders.Controller.Hook.PostProcess.ReleaseMetadata.json" `
			  -ReadmePath README-POSTPROCESS.md

./Publish.ps1 -ProjectPath "Riders.Controller.Hook/Riders.Controller.Hook.XInput/Riders.Controller.Hook.XInput.csproj" `
              -PackageName "Riders.Controller.Hook.XInput" `
              -PublishOutputDir "Publish/ToUpload/XInput" `
              -MetadataFileName "Riders.Controller.Hook.XInput.ReleaseMetadata.json" `
			  -ReadmePath README-XINPUT.md

./Publish.ps1 -ProjectPath "Riders.Controller.Hook/Riders.Controller.Hook/Riders.Controller.Hook.csproj" `
              -PackageName "Riders.Controller.Hook" `
              -PublishOutputDir "Publish/ToUpload/Hook" `
              -MetadataFileName "Riders.Controller.Hook.ReleaseMetadata.json" `
			  -ReadmePath README-HOOK.md

Pop-Location