dirname = File.dirname(__FILE__)
require 'albacore'
require "version_bumper"

build_mode = "Release"

desc "runs all tasks"
task :default => [:build]

desc "msbuild tasks"
msbuild :build do |msb|
	puts "building"
	msb.solution = "Autofac-Helpers.sln"
	msb.targets = [:Rebuild]
	msb.properties = {:Configuration => build_mode}
end

desc "build tests"
task :build_tests do
	puts "not implemented"
end

desc "pack"
nugetpack :nugetpack => [:bumpversion,:assemblyinfo,:build] do |nuget|
	nuget.command = ".nuget/NuGet.exe"
	nuget.nuspec = "Autofac.Helpers.csproj"
	nuget.parameters = ["-Prop Configuration=#{build_mode}"]
end

desc "push nuget package"
nugetpush do |nuget|
	nuget.command = ".nuget/NuGet.exe"
	nuget.package = "Autofac.Helpers.#{env_buildversion}.nupkg"
	nuget.apikey = ENV["nugetapikey"]
	nuget.source = ENV["nugetserver"]
end

desc "Run a sample assembly info generator"
assemblyinfo do |asm|
  asm.version =  env_buildversion
  asm.company_name = "TI24Horas"
  asm.product_name = "Autofac-Helpers"
  asm.title = "Autofac helpers"
  asm.description = "helpers for autofac"
  asm.copyright = ""
  
  asm.output_file = "Properties/AssemblyInfo.cs"
end

def env_buildversion
  bumper_version.to_s
end

task :bumpversion, :mode do |t,args|
	bump(args.mode || "build")
end

def bump(mode = :build)
	puts "bumping version #{mode}"
	bumper_version.send("bump_" + mode.to_s)
	bumper_version.write('VERSION')
end