
EXTRA_DIST =  

# Warning: This is an automatically generated file, do not edit!

if ENABLE_DEBUG
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG"
ASSEMBLY = bin/Debug/PluginInterface.dll
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug

PLUGININTERFACE_DLL_MDB_SOURCE=bin/Debug/PluginInterface.dll.mdb
PLUGININTERFACE_DLL_MDB=$(BUILD_DIR)/PluginInterface.dll.mdb

endif

if ENABLE_RELEASE
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+
ASSEMBLY = bin/Release/PluginInterface.dll
ASSEMBLY_MDB = 
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release

PLUGININTERFACE_DLL_MDB=

endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(PLUGININTERFACE_DLL_MDB)  

LINUX_PKGCONFIG = \
	$(PLUGININTERFACE_PC)  


RESGEN=resgen2
	
all: $(ASSEMBLY) $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

FILES = \
	Properties/AssemblyInfo.cs \
	Plugins/IPlugin.cs \
	PluginAttribute/DingerInfoAttribute.cs \
	PluginAttribute/PluginException/AttributeNotFoundException.cs \
	PluginAttribute/PluginExtraInfoAttribute.cs \
	PluginAttribute/PluginInfoAttribute.cs \
	Plugins/ExtraInfo.cs \
	Configure/ConfigureManager.cs \
	Plugins/SamplePluginBase.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	plugininterface.pc.in 

REFERENCES =  \
	System

DLL_REFERENCES = 

CLEANFILES = $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

include $(top_srcdir)/Makefile.include

PLUGININTERFACE_PC = $(BUILD_DIR)/plugininterface.pc

$(eval $(call emit-deploy-wrapper,PLUGININTERFACE_PC,plugininterface.pc))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'

$(ASSEMBLY_MDB): $(ASSEMBLY)

$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	mkdir -p $(shell dirname $(ASSEMBLY))
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
