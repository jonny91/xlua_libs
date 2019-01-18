# DO NOT EDIT
# This makefile makes sure all linkable targets are
# up-to-date with anything they link to
default:
	echo "Do not invoke directly"

# Rules to remove targets that are older than anything to which they
# link.  This forces Xcode to relink the targets from scratch.  It
# does not seem to check these dependencies itself.
PostBuild.xlua.Debug:
/Users/Jonny/Project/xlua_libs/build/build_ios/Debug${EFFECTIVE_PLATFORM_NAME}/libxlua.a:
	/bin/rm -f /Users/Jonny/Project/xlua_libs/build/build_ios/Debug${EFFECTIVE_PLATFORM_NAME}/libxlua.a


PostBuild.xlua.Release:
/Users/Jonny/Project/xlua_libs/build/build_ios/Release${EFFECTIVE_PLATFORM_NAME}/libxlua.a:
	/bin/rm -f /Users/Jonny/Project/xlua_libs/build/build_ios/Release${EFFECTIVE_PLATFORM_NAME}/libxlua.a


PostBuild.xlua.MinSizeRel:
/Users/Jonny/Project/xlua_libs/build/build_ios/MinSizeRel${EFFECTIVE_PLATFORM_NAME}/libxlua.a:
	/bin/rm -f /Users/Jonny/Project/xlua_libs/build/build_ios/MinSizeRel${EFFECTIVE_PLATFORM_NAME}/libxlua.a


PostBuild.xlua.RelWithDebInfo:
/Users/Jonny/Project/xlua_libs/build/build_ios/RelWithDebInfo${EFFECTIVE_PLATFORM_NAME}/libxlua.a:
	/bin/rm -f /Users/Jonny/Project/xlua_libs/build/build_ios/RelWithDebInfo${EFFECTIVE_PLATFORM_NAME}/libxlua.a




# For each target create a dummy ruleso the target does not have to exist
