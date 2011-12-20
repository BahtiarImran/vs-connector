SET GEM_PATH=vendor\ironruby\1.8
SET PATH=vendor\ironruby\1.8\bin;tools\ironruby\bin;
del /S /Q .bundle
call bundle install --path vendor

