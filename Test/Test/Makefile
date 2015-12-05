
EXTRA_DIST =  Makefile

# Warning: This is an automatically generated file, do not edit!

srcdir=.
top_srcdir=../..

include $(top_srcdir)/config.make

ifeq ($(CONFIG),DEBUG)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;"
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

ifeq ($(CONFIG),RELEASE)
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

PLUGINLOADER_DLL = $(BUILD_DIR)/PluginLoader.dll
PLUGININTERFACE_DLL = $(BUILD_DIR)/PluginInterface.dll
TEST = $(BUILD_DIR)/test

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

#Targets
all: $(ASSEMBLY) $(PROGRAMFILES) $(BINARIES)  $(top_srcdir)/config.make

include $(top_srcdir)/Makefile.include
#include $(srcdir)/custom-hooks.make



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
	make pre-all-local-hook prefix=$(prefix)
	mkdir -p $(shell dirname $(ASSEMBLY))
	make $(CONFIG)_BeforeBuild
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
	make $(CONFIG)_AfterBuild
	make post-all-local-hook prefix=$(prefix)

install-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-install-local-hook prefix=$(prefix)
	make install-satellite-assemblies prefix=$(prefix)
	mkdir -p '$(DESTDIR)$(libdir)/$(PACKAGE)'
	$(call cp,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(TEST_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(PLUGINLOADER_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(PLUGINLOADER_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(PLUGININTERFACE_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(PLUGININTERFACE_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	mkdir -p '$(DESTDIR)$(bindir)'
	$(call cp,$(TEST),$(DESTDIR)$(bindir))
	make post-install-local-hook prefix=$(prefix)

uninstall-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-uninstall-local-hook prefix=$(prefix)
	make uninstall-satellite-assemblies prefix=$(prefix)
	$(call rm,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(TEST_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(PLUGINLOADER_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(PLUGINLOADER_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(PLUGININTERFACE_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(PLUGININTERFACE_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(TEST),$(DESTDIR)$(bindir))
	make post-uninstall-local-hook prefix=$(prefix)

install: install-local
uninstall: uninstall-local
clean: clean-local

include $(top_srcdir)/rules.make
