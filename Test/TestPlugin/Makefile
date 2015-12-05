
EXTRA_DIST =  Makefile

# Warning: This is an automatically generated file, do not edit!

srcdir=.
top_srcdir=../..

include $(top_srcdir)/config.make

ifeq ($(CONFIG),DEBUG)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;"
ASSEMBLY = bin/Debug/TestPlugin.dll
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = library
PROJECT_REFERENCES =  \
	../Test/bin/Debug/Test.exe \
	../../PluginInterface/bin/Debug/PluginInterface.dll
BUILD_DIR = bin/Debug

TESTPLUGIN_DLL_MDB_SOURCE=bin/Debug/TestPlugin.dll.mdb
TESTPLUGIN_DLL_MDB=$(BUILD_DIR)/TestPlugin.dll.mdb
TEST_EXE_SOURCE=../Test/bin/Debug/Test.exe
TEST_EXE_MDB_SOURCE=../Test/bin/Debug/Test.exe.mdb
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
ASSEMBLY = bin/Release/TestPlugin.dll
ASSEMBLY_MDB = 
COMPILE_TARGET = library
PROJECT_REFERENCES =  \
	../Test/bin/Release/Test.exe \
	../../PluginInterface/bin/Release/PluginInterface.dll
BUILD_DIR = bin/Release

TESTPLUGIN_DLL_MDB=
TEST_EXE_SOURCE=../Test/bin/Release/Test.exe
TEST_EXE_MDB=
PLUGINLOADER_DLL_SOURCE=../../PluginLoader/bin/Release/PluginLoader.dll
PLUGINLOADER_DLL_MDB=
PLUGININTERFACE_DLL_SOURCE=../../PluginInterface/bin/Release/PluginInterface.dll
PLUGININTERFACE_DLL_MDB=

endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(TESTPLUGIN_DLL_MDB) \
	$(TEST_EXE) \
	$(TEST_EXE_MDB) \
	$(PLUGINLOADER_DLL) \
	$(PLUGINLOADER_DLL_MDB) \
	$(PLUGININTERFACE_DLL) \
	$(PLUGININTERFACE_DLL_MDB)  

LINUX_PKGCONFIG = \
	$(TESTPLUGIN_PC)  


RESGEN=resgen2

TEST_EXE = $(BUILD_DIR)/Test.exe
PLUGINLOADER_DLL = $(BUILD_DIR)/PluginLoader.dll
PLUGININTERFACE_DLL = $(BUILD_DIR)/PluginInterface.dll
TESTPLUGIN_PC = $(BUILD_DIR)/testplugin.pc

FILES = \
	MyClass.cs \
	Properties/AssemblyInfo.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	testplugin.pc.in 

REFERENCES =  \
	System

DLL_REFERENCES = 

CLEANFILES = $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

#Targets
all: $(ASSEMBLY) $(PROGRAMFILES) $(LINUX_PKGCONFIG)  $(top_srcdir)/config.make

include $(top_srcdir)/Makefile.include
#include $(srcdir)/custom-hooks.make



$(eval $(call emit-deploy-target,TEST_EXE))
$(eval $(call emit-deploy-target,TEST_EXE_MDB))
$(eval $(call emit-deploy-target,PLUGINLOADER_DLL))
$(eval $(call emit-deploy-target,PLUGINLOADER_DLL_MDB))
$(eval $(call emit-deploy-target,PLUGININTERFACE_DLL))
$(eval $(call emit-deploy-target,PLUGININTERFACE_DLL_MDB))
$(eval $(call emit-deploy-wrapper,TESTPLUGIN_PC,testplugin.pc))


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
	$(call cp,$(TESTPLUGIN_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(TEST_EXE),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(TEST_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(PLUGINLOADER_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(PLUGINLOADER_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(PLUGININTERFACE_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(PLUGININTERFACE_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	mkdir -p '$(DESTDIR)$(libdir)/pkgconfig'
	$(call cp,$(TESTPLUGIN_PC),$(DESTDIR)$(libdir)/pkgconfig)
	make post-install-local-hook prefix=$(prefix)

uninstall-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-uninstall-local-hook prefix=$(prefix)
	make uninstall-satellite-assemblies prefix=$(prefix)
	$(call rm,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(TESTPLUGIN_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(TEST_EXE),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(TEST_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(PLUGINLOADER_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(PLUGINLOADER_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(PLUGININTERFACE_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(PLUGININTERFACE_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(TESTPLUGIN_PC),$(DESTDIR)$(libdir)/pkgconfig)
	make post-uninstall-local-hook prefix=$(prefix)

install: install-local
uninstall: uninstall-local
clean: clean-local

include $(top_srcdir)/rules.make
