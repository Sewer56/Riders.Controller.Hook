$publishDirectory = "Publish"
Remove-Item $publishDirectory -Recurse

& .\PublishHook.ps1
& .\PublishCustom.ps1
& .\PublishPostProcess.ps1
& .\PublishXInput.ps1