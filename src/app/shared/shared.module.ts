import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule, registerLocaleData } from '@angular/common';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { HttpClient } from '@angular/common/http';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MaterialModule } from './modules/material/material.module';
import { HideEyeDirective } from './directives/hide-eye.directive';

export function httpTranslateLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}

const IMPORTS = [
  MaterialModule,
  TranslateModule.forRoot({
    loader: {
      provide: TranslateLoader,
      useFactory: httpTranslateLoaderFactory,
      deps: [HttpClient],
    },
  }),
  CommonModule,
  FlexLayoutModule,
];
const DECLARATIONS = [HideEyeDirective];
const EXPORTS = [HideEyeDirective];
const PROVIDERS = [];
const ENTRYCOMPONENT = [];
registerLocaleData('fa');
@NgModule({
  declarations: DECLARATIONS,
  imports: IMPORTS,
  exports : EXPORTS,
  // declarations: DECLARATIONS,
  // providers: PROVIDERS,
  // entryComponents: ENTRYCOMPONENT,
})
export class SharedModule {
  public static forRoot(): ModuleWithProviders<any> {
    return {
      ngModule: SharedModule,
    };
  }
}
