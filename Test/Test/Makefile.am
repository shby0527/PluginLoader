
EXTRA_DIST =  

# Warning: This is an automatically generated file, do not edit!

if ENABLE_DEBUG
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG"
ASSEMBLY = bin/Debug/Test.exe
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = exe
PROJECT_REFERENCES =  \
	../../PluginLoader/bin/Debug/PluginLoader.dll \
	../../PluginInterface/bin/Debug/PluginInterface.dll
BUILD_DIR = bin/Debug

TEST_EXE_MDB_SOURCE=bin/Debug/Test.exe.mdb
TEST_EXE_MDB=$(BUILD_DIR)/Test.exe.mdb
PLUGINLOADER_DLL_SOURCE=../../PluginLoader/bin/Debug/PluginLoader.dll
PLUGINLOADER_DLL_MDB_SOURCE=../../PluginLoader/bin/Debug/PluginLoader.dll.mdb
PLUGINLOADER_DLL_MDB=$(BUILD_DIR)/PluginLoader.dll.mdb
PLUGININTERFACE_DLL_SOURCE=../../PluginInterface/bin/Debug/PluginInterface.dll
PLUGININTERFACE_DLL_MDB_SOURCE=../../PluginInterface/bin/Debug/PluginInterface.dll.mdb
PLUGININTERFACE_DLL_MDB=$(BUILD_DIR)/PluginInterface.dll.mdb

endif

if ENABLE_RELEASE
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+
ASSEMBLY = bin/Release/Test.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = exe
PROJECT_REFERENCES =  \
	../../PluginLoader/bin/Release/PluginLoader.dll \
	../../PluginInterface/bin/Release/PluginInterface.dll
BUILD_DIR = bin/Release

TEST_EXE_MDB=
PLUGINLOADER_DLL_SOURCE=../../PluginLoader/bin/Release/PluginLoader.dll
PLUGINLOADER_DLL_MDB=
PLUGININTERFACE_DLL_SOURCE=../../PluginInterface/bin/Release/PluginInterface.dll
PLUGININTERFACE_DLL_MDB=

endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(TEST_EXE_MDB) \
	$(PLUGINLOADER_DLL) \
	$(PLUGINLOADER_DLL_MDB) \
	$(PLUGININTERFACE_DLL) \
	$(PLUGININTERFACE_DLL_MDB)  

BINARIES = \
	$(TEST)  


RESGEN=resgen2
	
all: $(ASSEMBLY) $(PROGRAMFILES) $(BINARIES) 

FILES = \
	Program.cs \
	Properties/AssemblyInfo.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	test.in 

REFERENCES =  \
	System

DLL_REFERENCES = 

CLEANFILES = $(PROGRAMFILES) $(BINARIES) 

include $(top_srcdir)/Makefile.include

PLUGINLOADER_DLL = $(BUILD_DIR)/PluginLoader.dll
PLUGININTERFACE_DLL = $(BUILD_DIR)/PluginInterface.dll
TEST = $(BUILD_DIR)/test

$(eval $(call emit-deploy-target,PLUGINLOADER_DLL))
$(eval $(call emit-deploy-target,PLUGINLOADER_DLL_MDB))
$(eval $(call emit-deploy-target,PLUGININTERFACE_DLL))
$(eval $(call emit-deploy-target,PLUGININTERFACE_DLL_MDB))
$(eval $(call emit-deploy-wrapper,TEST,test,x))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'

$(ASSEMBLY_MDB): $(ASSEMBLY)

$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	mkdir -p $(shell dirname $(ASSEMBLY))
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
