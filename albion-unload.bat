@echo off

echo Unoading
mono-assembly-injector -dll Albion\Release\Alucard.dll -target Albion-Online.exe -namespace Alucard -class Core -method Unload
