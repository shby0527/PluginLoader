
EXTRA_DIST =  

# Warning: This is an automatically generated file, do not edit!

if ENABLE_DEBUG
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG"
ASSEMBLY = bin/Debug/PluginLoader.dll
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = library
PROJECT_REFERENCES =  \
	../PluginInterface/bin/Debug/PluginInterface.dll
BUILD_DIR = bin/Debug

PLUGINLOADER_DLL_MDB_SOURCE=bin/Debug/PluginLoader.dll.mdb
PLUGINLOADER_DLL_MDB=$(BUILD_DIR)/PluginLoader.dll.mdb
PLUGININTERFACE_DLL_SOURCE=../PluginInterface/bin/Debug/PluginInterface.dll
PLUGININTERFACE_DLL_MDB_SOURCE=../PluginInterface/bin/Debug/PluginInterface.dll.mdb
PLUGININTERFACE_DLL_MDB=$(BUILD_DIR)/PluginInterface.dll.mdb

endif

if ENABLE_RELEASE
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+
ASSEMBLY = bin/Release/PluginLoader.dll
ASSEMBLY_MDB = 
COMPILE_TARGET = library
PROJECT_REFERENCES =  \
	../PluginInterface/bin/Release/PluginInterface.dll
BUILD_DIR = bin/Release

PLUGINLOADER_DLL_MDB=
PLUGININTERFACE_DLL_SOURCE=../PluginInterface/bin/Release/PluginInterface.dll
PLUGININTERFACE_DLL_MDB=

endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(PLUGINLOADER_DLL_MDB) \
	$(PLUGININTERFACE_DLL) \
	$(PLUGININTERFACE_DLL_MDB)  

LINUX_PKGCONFIG = \
	$(PLUGINLOADER_PC)  


RESGEN=resgen2
	
all: $(ASSEMBLY) $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

FILES = \
	Loader/PluginInfoCollection.cs \
	Properties/AssemblyInfo.cs \
	Loader/PluginLoader.cs \
	Loader/PluginInfo.cs \
	Loader/PluginCollection.cs \
	Loader/IPluginArray.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	pluginloader.pc.in 

REFERENCES =  \
	System \
	System.Core \
	System.Security \
	System.Data

DLL_REFERENCES = 

CLEANFILES = $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

include $(top_srcdir)/Makefile.include

PLUGININTERFACE_DLL = $(BUILD_DIR)/PluginInterface.dll
PLUGINLOADER_PC = $(BUILD_DIR)/pluginloader.pc

$(eval $(call emit-deploy-target,PLUGININTERFACE_DLL))
$(eval $(call emit-deploy-target,PLUGININTERFACE_DLL_MDB))
$(eval $(call emit-deploy-wrapper,PLUGINLOADER_PC,pluginloader.pc))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'

$(ASSEMBLY_MDB): $(ASSEMBLY)

$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	mkdir -p $(shell dirname $(ASSEMBLY))
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
